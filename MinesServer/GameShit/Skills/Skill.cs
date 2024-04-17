using MinesServer.Enums;
using MinesServer.GameShit.Entities.PlayerStaff;
using MinesServer.Network.GUI;

namespace MinesServer.GameShit.Skills
{
    public class Skill
    {
        public Skill()
        {
        }
        public int lvl = 1;
        public float exp = 0;
        public SkillType type;
        public Skill Clone()
        {
            return MemberwiseClone() as Skill;
        }
        public void Up(Player p)
        {
            if (isUpReady())
            {
                if ((long)Cost <= p.money)
                {
                    Dictionary<string, int> v = new();
                    exp -= Expiriense;
                    p.money -= (long)Cost;
                    lvl += 1;
                    v.Add(type.GetCode(), (int)((exp * 100f) / Expiriense));
                    p.connection?.SendU(new SkillsPacket(v));
                    p.SendMoney();
                    p.SendLvl();
                    p.SendHealth();
                    p.skillslist.Save();
                    if (EffectType() == SkillEffectType.OnMove)
                    {
                        p.SendSpeed();
                    }
                    if (type == SkillType.Health)
                    {
                        p.MaxHealth = 100+(int)Effect;
                        p.SendHealth();
                    }
                }
            }
        }
        public bool MeetReqs(Player p) => !GetReqs?.Select(i => p.skillslist.skills.Where(s => s.Value?.type == i.Key && s.Value?.lvl >= i.Value).Count() > 0).Contains(false) ?? true;
        public void AddExp(Player p, float expv = 1)
        {
            Dictionary<string, int> v = new();
            foreach (var i in p.skillslist.skills.Values)
            {
                if (UseSkill(SkillEffectType.OnExp, p))
                {
                    if (i.type == SkillType.Upgrade)
                    {
                        expv *= i.Effect;
                    }
                }
            }
            Random rand = new Random();
            if (Expiriense * 2.1 > exp)
            {
                exp += expv;
                v.Add(type.GetCode(), (int)((exp * 100f) / Expiriense));
                p.connection?.SendU(new SkillsPacket(v));
                p.skillslist.Save();
            }
            else
            {
                if(rand.Next((int)(exp / Expiriense)) <= (int)(exp / (Expiriense*2)))
                {
                    exp += expv;
                    v.Add(type.GetCode(), (int)((exp * 100f) / Expiriense));
                    p.connection?.SendU(new SkillsPacket(v));
                    p.skillslist.Save();
                }
            }
        }
        public bool UseSkill(SkillEffectType e, Player p)
        {
            if (e == EffectType())
            {
                return true;
            }
            return false;
        }
        public bool isUpReady()
        {
            return exp >= Expiriense;
        }
        public SkillEffectType EffectType()
        {
            return PlayerSkills.skillz.First(i => i.type == type).effecttype;
        }
        public float Expiriense { get
            {
                expfunc ??= PlayerSkills.skillz.FirstOrDefault(i => i.type == type).expfunc;
                return expfunc(lvl); 
            } }
        public string Description { get {
                description ??= PlayerSkills.skillz.FirstOrDefault(i => i.type == type)?.description!;
                if (description != null)
                {
                    return description(lvl, Effect, AdditionalEffect, Cost, exp, Expiriense);
                }
                return $"lvl:{lvl} effect:{Math.Round(Effect,2)} cost:{Cost} exp:{exp}/{Expiriense}";
                    } }
        public float Effect { get
            {
                effectfunc ??= PlayerSkills.skillz.FirstOrDefault(i => i.type == type).effectfunc;
                return effectfunc(lvl);
            }
        }
        public float AdditionalEffect
        {
            get
            {
                dopfunc ??= PlayerSkills.skillz.FirstOrDefault(i => i.type == type).dopfunc;
                return dopfunc == null ? 0 : dopfunc(lvl);
            }
        }
        public float Cost { get {
                costfunc ??= PlayerSkills.skillz.FirstOrDefault(i => i.type == type).costfunc;
                return costfunc(lvl);
            }
        }
        public Func<int, float,float, float, float, float, string> description {  
            private get;
            set;
        }
        public SkillEffectType effecttype { 
            private get;
            set;
        }
        public Func<int, float> expfunc {
            private get;
            set;
        }
        public Func<int, float> effectfunc { 
            private get; 
            set;
        }
        public Func<int, float> costfunc { 
            private get; 
            set; 
        }
        public Func<int, float> dopfunc
        {
            private get;
            set;
        }
        public Dictionary<SkillType, int>? requirements
        {
            get;
            set;
        }
        public Dictionary<SkillType,int>? GetReqs
        {
            get
            {
                requirements ??= PlayerSkills.skillz.FirstOrDefault(i => i.type == type)!.requirements;
                return requirements;
            }
        }
    }
}
