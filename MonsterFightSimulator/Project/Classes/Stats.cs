using System;

namespace MonsterFightSimulator.Project.Classes
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
        public Stats() { }
        public Stats(float health, float attack, float defense, float speed)
        {
            HealthMax = health;
            Health    = HealthMax;
            Attack    = attack;
            Defense   = defense;
            Speed     = speed;
        }

        public float Attack { get; set; } = 1f;
        public float Defense { get; set; } = 1f;
        public float Health { get; set; } = 1f;
        public float HealthMax { get; set; } = 1f;
        public float Speed { get; set; } = 1f;


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
                    StatType.HealthMax => HealthMax,
                    _ => throw new ArgumentOutOfRangeException(nameof(t), t, null)
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
                    default: throw new ArgumentOutOfRangeException(nameof(t), t, null);
                }
            }
        }

        public void UpdateHealthMax() => HealthMax = Health;
    }
}