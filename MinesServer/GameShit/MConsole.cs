using MinesServer.GameShit.ClanSystem;
using MinesServer.GameShit.Entities.PlayerStaff;
using MinesServer.GameShit.GUI;
using MinesServer.GameShit.GUI.Horb;
using MinesServer.GameShit.Sys_Miss;
using MinesServer.GameShit.SysMarket;
using MinesServer.GameShit.WorldSystem;
using MinesServer.Network.HubEvents;
using MinesServer.Network.World;
using MinesServer.Server;

namespace MinesServer.GameShit
{
    public static class MConsole
    {
        public static void InitCommands()
        {
            commands.Add("tp", (p, args) =>
            {
                if (p.id == 1)
                {
                    var arr = args.Split(" ");
                    if (arr.Length > 1 && int.TryParse(arr[1], out var x) && int.TryParse(arr[2], out var y))
                    {
                        p.x = x;
                        p.y = y;
                        p.tp(x, y);
                    }
                }
            });
            commands.Add("boomorder", (p, args) => {
                if (p.id == 1)
                {
                    MarketSystem.GenerateRandomOrders();
                }
            });

            commands.Add("cryaliable", (p, args) =>
            {
            for (int i = 0; i < World.W.cryscostmod.Length; i++)
            {
                Console.WriteLine((World.W.summary[i] + World.W.summary.Sum()) / 100);
                    if (args.Split(" ").Length > 1 && int.TryParse(args.Split(" ")[1], out var o))
                    {
                        var c = (World.W.summary[i] + World.W.summary.Sum()) / 100;
                        if (c > 0)
                        {

                            World.W.cryscostmod[c] = i;
                        }
                    }
                }
                World.W.summary = new long[6];
                World.lastcryupdate = ServerTime.Now;
                AddConsoleLine(p, "ok: " + World.W.cryscostmod.Length);
            });



            commands.Add("tpplayer", (p, args) => {
                if (p.id == 1)
                {
                    if (args.Split(" ").Length > 1 && int.TryParse(args.Split(" ")[1], out var i))
                    {

                        var valid = bool (int x, int y) => (x >= 0 && y >= 0) && (x < World.ChunksW && y < World.ChunksH);
                        for (var xxx = 0; xxx <= World.ChunksW; xxx++)
                        {
                            for (var yyy = 0; yyy <= World.ChunksH; yyy++)
                            {
                                if (valid(xxx, yyy))
                                {
                                    var ch = World.W.chunks[xxx, yyy];
                                    foreach (var id in ch.bots)
                                    {
                                        var player = DataBase.GetPlayer(id.Key);
                                        if (player.id == i)
                                        {
                                            p.x = player.x;
                                            p.y = player.y;
                                            p.tp(p.x, p.y);
                                            AddConsoleLine(p, "ok");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            commands.Add("fedresp", (p, arg) =>
            {
                p.RandomResp();
            });
            commands.Add("clans", (p, arg) =>
            {
                Clan.OpenClanList(p);
            });
            commands.Add("setitem", (p, arg) =>
            {
                if (p.id == 1)
                {
                    if (arg.Split(" ").Length > 1 && int.TryParse(arg.Split(" ")[1], out var i) && int.TryParse(arg.Split(" ")[2], out var c))
                    {
                        p.inventory[i] = c;
                        AddConsoleLine(p, "ok");
                        p.SendInventory();
                    }
                }
            });
            commands.Add("addgeo", (p, arg) =>
            {
                if (p.id == 1)
                {
                    if (arg.Split(" ").Length > 1 && byte.TryParse(arg.Split(" ")[1], out var i))
                    {
                        p.geo.Push(i);
                        p.SendGeo();
                    }
                }
            });
            commands.Add("addmoney", (p, arg) =>
            {
                if (p.id == 1)
                {
                    if (arg.Split(" ").Length > 1 && int.TryParse(arg.Split(" ")[1], out var i))
                    {
                        p.money += i;
                        AddConsoleLine(p, "ok");
                        p.SendMoney();
                    }
                }
            });
            commands.Add("myid", (p, arg) =>
            {
                AddConsoleLine(p, p.id.ToString());
            });
            commands.Add("getallmap", (p, arg) =>
            {
                if (p.id == 1)
                {
                    for (int x = 0; x < World.ChunksW; x++)
                    {
                        for (int y = 0; y < World.ChunksH; y++)
                        {
                            p.connection?.SendB(new HBPacket([new HBMapPacket(x * 32, y * 32, 32, 32, World.W.chunks[x, y].cells)]));
                        }
                    }
                }
            });
            commands.Add("setnick", (p, arg) =>
            {
                if (arg.Split(' ').Length > 0)
                {
                    p.name = arg.Split(' ')[1];
                    using var db = new DataBase();
                    db.SaveChanges();
                    db.Dispose();
                }
            });
            //commands.Add("addmis", (p, arg) =>
            //{
            //Task.Run(() =>
            //new Misson().SendMisson(p));
            //});
        }
        public static void AddConsoleLine(Player p)
        {
            p.console.Enqueue(new Line { text = ">    " });
            if (p.console.Count > 16)
            {
                p.console.Dequeue();
                var l = p.console.Peek();
                l.text = "@@" + l.text;
            }
        }
        public static void AddConsoleLine(Player p, string text)
        {
            p.console.Enqueue(new Line { text = ">" + text });
            if (p.console.Count > 16)
            {
                p.console.Dequeue();
                var l = p.console.First();
                l.text = "@@" + l.text;
            }
        }
        public static void ShowConsole(Player p)
        {
            p.win = new Window()
            {
                Title = "Консоль",
                Tabs = [new Tab()
                {
                    Label = "",
                    Action = "console",
                    InitialPage = new Page()
                    {
                        Input = new InputConfig()
                        {
                            Placeholder = "cmd",
                            IsConsole = true
                        },
                        ClanList = [],
                        Text = string.Join("", p.console.Select(x => x.text + '\n').ToArray()),
                        Buttons = [new MButton("ВЫПОЛНИТЬ", $"{ActionMacros.Input}", (args) =>
                        {
                            var msg = args.Input!;
                            AddConsoleLine(p, msg);
                            if (msg.Contains(' '))
                            {
                                if (commands.Keys.Contains(msg.Split(' ')[0]))
                                {
                                    commands[msg.Split(' ')[0]](p, msg);
                                    ShowConsole(p);
                                    return;
                                }
                            }
                            if (commands.Keys.Contains(msg))
                            {
                                commands[msg](p, msg);
                                if (!msg.StartsWith("clans"))
                                    ShowConsole(p);
                                return;
                            }
                            AddConsoleLine(p, "Неизвестная команда");
                            ShowConsole(p);
                        })]
                    }
                }],
                ShowTabs = false
            };
            p.SendWindow();
        }
        public delegate void Command(Player p, string args);
        public static Dictionary<string, Command> commands = new Dictionary<string, Command>();
    }
    public class Line
    {
        public string text { get; set; }
    }
}
