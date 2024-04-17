using MinesServer.Enums;
using MinesServer.GameShit.GUI.UP;
using MinesServer.GameShit.Skills;
using MinesServer.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace MinesServer.GameShit.Entities.PlayerStaff
{
    public class PlayerSkills
    {
        [Key]
        public int id { get; set; }
        public string ser { get; set; } = "";
        public void LoadSkills()
        {
            if (skills.Count < 1)
            {
                skills = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, Skill?>>(ser);
            }
        }
        [NotMapped]
        public int selectedslot = -1;
        
        public void DeleteSkill(Player p)
        {
            if (!skills.ContainsKey(selectedslot))
            {
                return;
            }
            skills[selectedslot] = null;
            p.SendLvl();
            Save();
        }
        public void InstallSkill(string type, int slot, Player p)
        {
            if (skills.ContainsKey(slot) && skills[slot] != null || slot > slots || slot < 0 || !skillz.First(i => i.type.GetCode() == type).MeetReqs(p))
            {
                return;
            }
            var s = new Skill();
            skills[slot] = skillz.First(i => i.type.GetCode() == type).Clone();
            p.SendLvl();
            Save();
        }
        public void Save()
        {
            using var db = new DataBase();
            db.skills.Attach(this);
            ser = Newtonsoft.Json.JsonConvert.SerializeObject(skills, Newtonsoft.Json.Formatting.None);
            db.SaveChanges();
        }
        public Dictionary<SkillType, bool> SkillToInstall(Player p)
        {
            Dictionary<SkillType, bool> d = new();
            foreach (var sk in skillz)
            {
                if (skills.FirstOrDefault(skill => skill.Value?.type == sk.type).Value == null && sk.MeetReqs(p))
                {
                    d.Add(sk.type, true);
                }
            }
            return d;
        }
        public int lvlsummary() => skills.Sum(i => i.Value?.lvl ?? 0);
        public UpSkill[] GetSkills()
        {
            List<UpSkill> ski = new();
            LoadSkills();
            foreach (var i in skills)
            {
                if (i.Value != null)
                {
                    ski.Add(new UpSkill(i.Key, i.Value.lvl, i.Value.isUpReady(), i.Value.type));
                }
            }
            return ski.ToArray();
        }
        public int slots { get; set; } = 12;
        [NotMapped]
        public Dictionary<int, Skill?> skills = new();
        [NotMapped]
        public static List<Skill> skillz = new List<Skill>()
        {
                new Skill()
                {
                    requirements = null,
                    costfunc = (int x) => CoeffSkill.Digcoast((float)x),
                    effectfunc = (int x) => CoeffSkill.Digeffect((float)x),
                    expfunc = (int x) => CoeffSkill.Digexp((float)x),
                    type = SkillType.Digging, // dick
                    effecttype = SkillEffectType.OnDig,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Копание. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nЭффективность лампы: {effect}%\nПозволяет уничтожать объекты в мире\nКак качать: копать\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { {SkillType.BuildGreen,4} },
                    costfunc = (int x) => CoeffSkill.Roadcoast(x),
                    effectfunc = (int x) => CoeffSkill.Roadeffect(x),
                    expfunc = (int x) => CoeffSkill.Roadexp(x),
                    type = SkillType.BuildRoad,
                    effecttype = SkillEffectType.OnBld,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Постройка дорог. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nСтоимость в кри: {effect}\nПозволяет строить дороги для быстрого передвижения\nКак качать: строить дороги\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { {SkillType.Digging,4} },
                    costfunc = (int x) => CoeffSkill.Greencoast(x),
                    effectfunc = (int x) => CoeffSkill.Greeneff(x),
                    expfunc = (int x) => CoeffSkill.Greenexp(x),
                    dopfunc = (x) => x,
                    type = SkillType.BuildGreen,
                    effecttype = SkillEffectType.OnBld,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Постройка зеленых. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет строить зелёные блоки\nКак качать: строить зел. блоки\nСтоимость блока в кри: {effect}\nПрочность блока в ударах: {dopeffect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { {SkillType.BuildGreen,6} },
                    costfunc = (int x) => CoeffSkill.Yellowcoast(x),
                    effectfunc = (int x) => CoeffSkill.Yelloweffect(x),
                    expfunc = (int x) => CoeffSkill.Yellowexp(x),
                    dopfunc = (x) => x,
                    type = SkillType.BuildYellow,
                    effecttype = SkillEffectType.OnBld,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Постройка жёлтых. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет строить жёлтые блоки\nКак качать: строить желт. блоки\nСтоимость блока в кри: {effect}\nПрочность блока в ударах: {dopeffect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                 new Skill()
                {
                    requirements = new() { {SkillType.BuildYellow,6} },
                    costfunc = (int x) => CoeffSkill.Redcoast(x),
                    effectfunc = (int x) => CoeffSkill.Redeffect(x),
                    expfunc = (int x) => CoeffSkill.Redexp(x),
                    dopfunc = (x) => x,
                    type = SkillType.BuildRed,
                    effecttype = SkillEffectType.OnBld,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Постройка красных. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет строить красные блоки\nКак качать: строить крас. блоки\nСтоимость блока в кри: {effect}\nПрочность блока в ударах: {dopeffect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { {SkillType.BuildGreen,4} },
                    costfunc = (int x) => CoeffSkill.Oporacoast(x),
                    effectfunc = (int x) => CoeffSkill.Oporaeffect(x),
                    expfunc = (int x) => CoeffSkill.Oporaexp(x),
                    type = SkillType.BuildStructure,
                    effecttype = SkillEffectType.OnBld,
                     description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Постройка опор. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет строить опоры\nКак качать: строить опоры\nСтоимость блока в кри: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                 new Skill()
                {
                    requirements = new() { {SkillType.Digging,1000} },
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    dopfunc = (x) => x,
                    expfunc = (x) => 1f,
                    type = SkillType.BuildWar,
                    effecttype = SkillEffectType.OnBld,
                     description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Военный блок. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет строить военные блоки\nКак качать: строить воен. блоки\nСтоимость блока в кри: {effect}\nПрочность блока в ударах: {dopeffect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { {SkillType.Digging,4 } },
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.Fridge, // охлад
                    effecttype = SkillEffectType.OnMove
                },
                new Skill()
                {
                    requirements = null,
                    costfunc = (int x) => CoeffSkill.Movecoast(x),
                    effectfunc = (int x) => 70f - x * 0.05f > 30f ? 70f - x * 0.05f : 30f,
                    expfunc = (int x) => CoeffSkill.Moveexp(x),
                    type = SkillType.Movement, // движение,
                    effecttype = SkillEffectType.OnMove,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Передвижение. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет передвигаться роботу\nКак качать: ходить\nСкорость передвижения: {Math.Round(1 / (effect * 1.2f * 0.001f) * 0.3f * 3.6f,2)} км/ч\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { {SkillType.Movement,10 } },
                    costfunc = (int x) => 20000000f,
                    effectfunc = (int x) => 4f,
                    expfunc = (int x) => 20000000f,
                    type = SkillType.RoadMovement, // по дорогам
                    effecttype = SkillEffectType.OnMove,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Передвижение по дорогам. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет передвигаться роботу быстрее по дороге\nКак качать: ходить по дорогам\nСкорость передвижения: {effect}%\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 5 },{ SkillType.Movement,2 } },
                    costfunc = (int x) => CoeffSkill.Capacitycoast(x),
                    effectfunc = (int x) => CoeffSkill.Capacityeffect(x),
                    expfunc = (int x) => CoeffSkill.Capacityexp(x),
                    type = SkillType.Packing, // упаковка
                    effecttype = SkillEffectType.OnPackCrys
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 5 } },
                    costfunc = (int x) => CoeffSkill.Hpcoast((float)x),
                    effectfunc = (int x) => CoeffSkill.Hpeffect((float)x),
                    expfunc = (int x) => CoeffSkill.Hpexp((float)x),
                    type = SkillType.Health, // хп
                    effecttype = SkillEffectType.OnHealth,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Здоровье. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет увеличивать прочность робота\nКак качать: получать урон\nЗдоровье: {effect+100}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = null,
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.PackingBlue, // упаковка синь
                    effecttype = SkillEffectType.OnPackCrys
                },
                new Skill()
                {
                    requirements = null,
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.PackingCyan, // упаковка голь
                    effecttype = SkillEffectType.OnPackCrys
                },
                 new Skill()
                {
                     requirements = null,
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.PackingGreen, // упаковка зель
                    effecttype = SkillEffectType.OnPackCrys
                },
                  new Skill()
                {
                      requirements = null,
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.PackingRed, // упаковка крась
                    effecttype = SkillEffectType.OnPackCrys
                },
                    new Skill()
                {
                        requirements = null,
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.PackingViolet, // упаковка фиоль
                    effecttype = SkillEffectType.OnPackCrys
                },
                new Skill()
                {
                    requirements = null,
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 1f,
                    expfunc = (x) => 1f,
                    type = SkillType.PackingWhite, // упаковка бель
                    effecttype = SkillEffectType.OnPackCrys
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 10 } },
                    costfunc = (int x) => CoeffSkill.Minecoast((float)x),
                    effectfunc = (int x) => CoeffSkill.Mineeffect((float)x),
                    expfunc = (int x) => CoeffSkill.Mineexp((float)x),
                    type = SkillType.MineGeneral, // доба
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет получать кристаллы\nКак качать: копать кри\nКри за удар: {effect+1}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 1000 } },
                    costfunc = (x) => 1f,
                    effectfunc = (x) => 100f + x * 0.2f,
                    expfunc = (x) => 1f,
                    type = SkillType.Induction, // инда
                    effecttype = SkillEffectType.OnHurt
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Health, 12 } },
                    costfunc = (int x) =>CoeffSkill.Zopcoast(x),
                    effectfunc = (int x) =>  CoeffSkill.Zopeffect(x),
                    expfunc = (int x) => CoeffSkill.Zopexp(x),
                    type = SkillType.AntiGun, // антипуфка
                    effecttype = SkillEffectType.OnHurt
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Health, 10 } },
                    costfunc = (x) => CoeffSkill.Healcoast(x),
                    effectfunc = (x) => CoeffSkill.Healeff(x),
                    expfunc = (x) => CoeffSkill.Healexp(x),
                    type = SkillType.Repair, // хил
                    effecttype = SkillEffectType.OnHealth,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Ремонт. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nРемонтирует робота\nКак качать: чинить робота [ V ]\nРемонтирует: {effect} хп/ крас.кри\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 11 } },
                    costfunc = (int x) => CoeffSkill.GMineCricoast(x),
                    effectfunc = (int x) => CoeffSkill.GMineCrieffect(x),
                    expfunc = (int x) => CoeffSkill.GMineCriexp(x),
                    type = SkillType.MineGreen, // Добыча зели
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча зелёных. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет добывать больше зелёных кристаллов\nКак качать: копать зел. кри\nДополнительно кри за удар: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 13 } },
                    costfunc = (int x) => CoeffSkill.BMineCricoast(x),
                    effectfunc = (int x) => CoeffSkill.BMineCrieff(x),
                    expfunc = (int x) => CoeffSkill.BMineCriexp(x),
                    type = SkillType.MineBlue, // Добыча сини
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча синих. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет добывать больше синих кристаллов\nКак качать: копать син. кри\nДополнительно кри за удар: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 15 } },
                    costfunc = (int x) => CoeffSkill.RMineCricoast(x),
                    effectfunc = (int x) => CoeffSkill.RMineCrieff(x),
                    expfunc = (int x) => CoeffSkill.RMineCriexp(x),
                    type = SkillType.MineRed, // Добыча краси
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча красных. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет добывать больше красных кристаллов\nКак качать: копать крас. кри\nДополнительно кри за удар: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 18 } },
                    costfunc = (int x) => CoeffSkill.WMineCricoast(x),
                    effectfunc = (int x) => CoeffSkill.WMineCrieff(x),
                    expfunc = (int x) => CoeffSkill.WMineCriexp(x),
                    type = SkillType.MineWhite, // добыча бели
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча белых. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет добывать больше белых кристаллов\nКак качать: копать бел. кри\nДополнительно кри за удар: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 21 } },
                    costfunc = (int x) => CoeffSkill.VMineCricoast(x),
                    effectfunc = (int x) => CoeffSkill.VMineCrieff(x),
                    expfunc = (int x) => CoeffSkill.VMineCriexp(x),
                    type = SkillType.MineViolet, // добыча фиоли
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча фиолетовых. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет добывать больше фиолетовых кристаллов\nКак качать: копать фиол. кри\nДополнительно кри за удар: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                },
                new Skill()
                {
                    requirements = new() { { SkillType.Digging, 25 } },
                    costfunc = (int x) => CoeffSkill.CMineCricoast(x),
                    effectfunc = (int x) => CoeffSkill.CMineCrieff(x),
                    expfunc = (int x) => CoeffSkill.CMineCrixp(x),
                    type = SkillType.MineCyan, // добыча голи
                    effecttype = SkillEffectType.OnDigCrys,
                    description = (lvl,effect,dopeffect,cost,expcurrent,expneed) =>
                    {
                        return $"Добыча голубых. Уровень: {lvl}\nОпыт - {expcurrent}/{expneed}\nПозволяет добывать больше голубых кристаллов\nКак качать: копать гол. кри\nДополнительно кри за удар: {effect}\nСлед. уровень: {cost.ToString("N0", new NumberFormatInfo()).Replace("," , " ")}$";
                    }
                }

        };
    }
}
