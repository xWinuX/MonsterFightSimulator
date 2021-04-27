using System;

namespace MonsterFightSimulator.Project
{
    public class MonsterStats : IHealth, IStats
    {
        public MonsterStats()
        {
            HealthMax = HealthRange.MinValue;
            Health    = HealthMax;
            Attack    = AttackRange.MinValue;
            Defense   = DefenseRange.MinValue;
        }
        
        public MonsterStats(float health, float attack, float defense)
        {
            HealthMax = health;
            Health    = health;
            Attack    = attack;
            Defense   = defense;
        }

        public float Health { get; set; }
        public float HealthMax { get; set; }
        public float Attack { get; set; }
        public float Defense { get; set; }

        public static readonly Range HealthRange = new Range(1, 20);
        public static readonly Range AttackRange = new Range(1, 3);
        public static readonly Range DefenseRange = new Range(0, 5);

        public static MonsterStats GetRandom() { return GetRandom(new Random()); }

        public static MonsterStats GetRandom(Random random)
        {
            return new MonsterStats(HealthRange.GetRandomBetween(random), AttackRange.GetRandomBetween(random), DefenseRange.GetRandomBetween(random));
        }
    }
}