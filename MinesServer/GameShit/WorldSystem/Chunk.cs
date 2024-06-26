﻿using MinesServer.GameShit.Buildings;
using MinesServer.GameShit.Entities.PlayerStaff;
using MinesServer.Network.HubEvents.FX;
using MinesServer.Network.HubEvents.Packs;
using MinesServer.Network.World;
using MinesServer.Server;
using System.Collections.Concurrent;

namespace MinesServer.GameShit.WorldSystem
{
    public class Chunk
    {
        public ConcurrentDictionary<int, Player> bots = new();
        public (int, int) pos;
        public bool[] packsprop;
        public bool active = false;
        public Chunk((int, int) pos) => this.pos = pos;
        public bool ContainsAlive = false;
        public Dictionary<int, Pack> packs = new();
        private byte this[int x, int y]
        {
            get => World.GetCell(WorldX + x, WorldY + y);
            set => World.SetCell(WorldX + x, WorldY + y, value);
        }
        public int WorldX
        {
            get => pos.Item1 * 32;
        }
        public int WorldY
        {
            get => pos.Item2 * 32;
        }
        private DateTimeOffset lastupdalive = ServerTime.Now;
        private DateTimeOffset sandandb = ServerTime.Now;
        private DateTimeOffset notvisibleupd = ServerTime.Now;
        public byte[] cells => Enumerable.Range(0, World.ChunkHeight).SelectMany(y => Enumerable.Range(0, World.ChunkWidth).Select(x => this[x, y])).ToArray();
        public void Update()
        {
            var now = ServerTime.Now;
            
            if (shouldbeloaded())
            {
                CheckBots();
                updlasttick = false;
                UpdateCells();
                return;
            }
            else if (now - notvisibleupd > TimeSpan.FromHours(5))
            {
                UpdateNotVisible();
                notvisibleupd = now;
            }
            Dispose();
        }
        public void SetCell(int x, int y, byte cell, bool packmesh = false)
        {
            LoadPackProps();
            packsprop[x + y * 32] = packmesh ? true : false;
            if (active)
            {
                SendCellToBots(WorldX + x, WorldY + y, this[x, y]);
            }
        }
        public void UpdateNotVisible()
        {
            for (int lx = 0; lx < 32; lx++)
            {
                for (int ly = 0; ly < 32; ly++)
                {
                    (int x, int y) d = (WorldX + lx, WorldY + ly);
                    if (World.isCry(World.GetCell(d.x, d.y)))
                    {
                        if (World.GetDurability(d.x, d.y) < 20) 
                        World.SetDurability(d.x, d.y, World.GetDurability(d.x, d.y) + 1);
                        else World.SetDurability(d.x, d.y, 20);
                    }
                }
            }
        }
        public void LoadPackProps()
        {
            if (packsprop == null)
            {
                packsprop = new bool[1024];
                foreach (var p in packs.Values)
                {
                    p.Build();
                }
            }
        }
        public void DestroyCell(int x, int y, World.destroytype t)
        {
            if (active)
            {
                SendCellToBots(WorldX + x, WorldY + y, this[x, y]);
            }
        }
        public void SendDirectedFx(int fx, int x, int y, int dir, int bid = 0, int color = 0)
        {
            for (var xxx = -2; xxx <= 2; xxx++)
            {
                for (var yyy = -2; yyy <= 2; yyy++)
                {
                    var cx = pos.Item1 + xxx;
                    var cy = pos.Item2 + yyy;
                    if (valid(cx, cy))
                    {
                        var ch = World.W.chunks[cx, cy];
                        foreach (var id in ch.bots)
                        {
                            DataBase.GetPlayer(id.Key)?.connection?.SendB(new HBPacket([new HBDirectedFXPacket(id.Key, x, y, fx, dir, color)]));
                        }
                    }
                }
            }
        }
        public void SendFx(int x, int y, int fx)
        {
            for (var xxx = -2; xxx <= 2; xxx++)
            {
                for (var yyy = -2; yyy <= 2; yyy++)
                {
                    var cx = pos.Item1 + xxx;
                    var cy = pos.Item2 + yyy;
                    if (valid(cx, cy))
                    {
                        var ch = World.W.chunks[cx, cy];
                        foreach (var id in ch.bots)
                        {
                            DataBase.GetPlayer(id.Key)?.connection?.SendB(new HBPacket([new HBFXPacket(x, y, fx)]));
                        }
                    }
                }
            }
        }
        public void ResendPacks()
        {
            foreach (var p in packs.Values)
            {
                if (p.type != 0)
                {
                    SendPack((char)p.type, p.x, p.y, p.cid, p.off);
                }
            }
        }
        public void ResendPack(Pack p)
        {
            if (p.type != 0)
            {
                SendPack((char)p.type, p.x, p.y, p.cid, p.off);
            }
        }
        public void SendPack(char type, int x, int y, int cid, int off)
        {
            for (var xxx = -2; xxx <= 2; xxx++)
            {
                for (var yyy = -2; yyy <= 2; yyy++)
                {
                    var cx = pos.Item1 + xxx;
                    var cy = pos.Item2 + yyy;
                    if (valid(cx, cy))
                    {
                        var ch = World.W.chunks[cx, cy];
                        foreach (var id in ch.bots)
                        {
                            ClearPack(x, y);
                            DataBase.GetPlayer(id.Key)?.connection?.SendB(new HBPacket([new HBPacksPacket(x + y * World.CellsHeight, [new HBPack(type, x, y, (byte)cid, (byte)off)])]));
                        }
                    }
                }
            }
        }
        public void ClearPack(int x, int y)
        {
            for (var xxx = -2; xxx <= 2; xxx++)
            {
                for (var yyy = -2; yyy <= 2; yyy++)
                {
                    var cx = pos.Item1 + xxx;
                    var cy = pos.Item2 + yyy;
                    if (valid(cx, cy))
                    {
                        var ch = World.W.chunks[cx, cy];
                        foreach (var id in ch.bots)
                        {
                            DataBase.GetPlayer(id.Key)?.connection?.SendB(new HBPacket([new HBPacksPacket(x + y * World.CellsHeight, [])]));
                        }
                    }
                }
            }
        }
        public Pack? GetPack(int x, int y) => packs.ContainsKey(x + y * 32) ? packs[x + y * 32] : null;
        public void SetPack(int x, int y, Pack p)
        {
            packs[x + y * 32] = p;
            if (p.type != 0)
            {
                SendPack((char)p.type, WorldX + x, WorldY + y, p.cid, p.off);
            }
        }
        public void RemovePack(int x, int y)
        {
            if (packs.ContainsKey(x + y * 32))
            {
                packs.Remove(x + y * 32);
                ClearPack(WorldX + x, WorldY + y);
            }
        }
        private void CheckBots()
        {
            foreach (var i in bots)
            {
                if (i.Value.ChunkX != pos.Item1 || i.Value.ChunkY != pos.Item2 || !DataBase.activeplayers.Contains(i.Value))
                {
                    bots.Remove(i.Value.id, out var p);
                }
            }
        }
        private void UpdateSandBoulders()
        {
            List<(int, int, byte)> cellstoupd = new();
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
            {
            
                    var prop = World.GetProp(this[x, y]);
                    if (prop.isSand || prop.isBoulder)
                    {
                        cellstoupd.Add((WorldX + x, WorldY + y, this[x, y]));
                    }
                }
            }
            foreach (var c in cellstoupd)
            {
                if (World.GetProp(c.Item3).isSand && Physics.Sand(c.Item1, c.Item2))
                {
                    updlasttick = true;
                }
                else if (World.GetProp(c.Item3).isBoulder && Physics.Boulder(c.Item1, c.Item2))
                {
                    updlasttick = true;
                }
            }
        }
        private void UpdateAlive()
        {
            List<(int, int, byte)> cellstoupd = new();
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    var prop = World.GetProp(this[x, y]);
                    if (World.isAlive(this[x, y]))
                    {
                        cellstoupd.Add((WorldX + x, WorldY + y, this[x, y]));
                    }
                }
            }
            foreach (var c in cellstoupd)
            {
                if (World.isAlive(c.Item3) && Physics.Alive(c.Item1, c.Item2))
                {
                    updlasttick = true;
                }
            }
        }
        private void UpdateCells()
        {
            var now = ServerTime.Now;
            if (now - lastupdalive > TimeSpan.FromMinutes(2))
            {
                UpdateAlive();
                lastupdalive = now;
            }
            if (now - sandandb > TimeSpan.FromMilliseconds(400))    
            {
                UpdateSandBoulders();
                sandandb = now;
            }
        }
        private bool updlasttick = false;
        public void AddBot(Player player)
        {
            if (this != null && !bots.ContainsKey(player.id))
            {
                bots[player.id] = player;
            }
        }
        public bool shouldbeloaded()
        {
            return active && (ShouldBeLoadedBots() || ContainsAlive || updlasttick);
        }
        public void Dispose()
        {
            World.W.cells.Unload(pos.Item1, pos.Item2);
        }
        private bool ShouldBeLoadedBots()
        {
            for (var xxx = -2; xxx <= 2; xxx++)
            {
                for (var yyy = -2; yyy <= 2; yyy++)
                {
                    var cx = pos.Item1 + xxx;
                    var cy = pos.Item2 + yyy;
                    if (valid(cx, cy))
                    {
                        var ch = World.W.chunks[cx, cy];
                        if (ch.bots.Count > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool valid(int x, int y) => x >= 0 && y >= 0 && x < World.ChunksW && y < World.ChunksH;
        private void SendCellToBots(int x, int y, byte cell)
        {
            for (var xxx = -2; xxx <= 2; xxx++)
            {
                for (var yyy = -2; yyy <= 2; yyy++)
                {
                    var cx = pos.Item1 + xxx;
                    var cy = pos.Item2 + yyy;
                    if (valid(cx, cy))
                    {
                        var ch = World.W.chunks[cx, cy];
                        foreach (var id in ch.bots)
                        {
                            DataBase.GetPlayer(id.Key)?.connection?.SendCell(x, y, cell);
                        }
                    }
                }
            }
        }
    }
}
