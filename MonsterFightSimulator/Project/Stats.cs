using System;

namespace MonsterFightSimulator.Project
{
    public enum StatType
    {
        Health,
        Attack,
        Defense,
        Speed,
        HealthMax
    }

    public class Stats
    {
        public Stats(StatsRangeProfile rangeProfile)
        {
            HealthMax = rangeProfile.HealthRange.MinValue;
            Health    = HealthMax;
            Attack    = rangeProfile.AttackRange.MinValue;
            Defense   = rangeProfile.DefenseRange.MinValue;
            Speed     = rangeProfile.SpeedRange.MinValue;
        }

        public Stats(float health, float attack, float defense, float speed)
        {
            HealthMax = health;
            Health    = HealthMax;
            Attack    = attack;
            Defense   = defense;
            Speed     = speed;
        }

        public float Attack { get; set; }
        public float Defense { get; set; }
        public float Health { get; set; }
        public float HealthMax { get; set; }

        public float this[StatType t]
        {
            get
            {
                return t switch
                {
                    StatType.Health    => Health,
                    StatType.Attack    => Attack,
                    StatType.Defense   => Defense,
                    StatType.Speed     => Speed,
                    StatType.HealthMax => HealthMax
                };
            }
            set
            {
                switch (t)
                {
                    case StatType.Health:    Health    = value; break;
                    case StatType.Attack:    Attack    = value; break;
                    case StatType.Defense:   Defense   = value; break;
                    case StatType.Speed:     Speed     = value; break;
                    case StatType.HealthMax: HealthMax = value; break;
                }
            }
        }

        public float Speed { get; set; }

        public void UpdateHealthMax() => HealthMax = Health;
    }
}