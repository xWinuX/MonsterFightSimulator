using System;
using Range = MonsterFightSimulator.Engine.Core.Range;

namespace MonsterFightSimulator.Project
{
    public class StatsRangeProfile
    {
        public StatsRangeProfile(Range healthRange, Range attackRange, Range defenseRange, Range speedRange)
        {
            HealthRange  = healthRange;
            AttackRange  = attackRange;
            DefenseRange = defenseRange;
            SpeedRange   = speedRange;
        }

        public Range HealthRange { get; }
        public Range AttackRange { get; }
        public Range DefenseRange { get; }
        public Range SpeedRange { get; }
        
        
        public Range this[StatType t]
        {
            get
            {
                return t switch
                {
                    StatType.Health => HealthRange,
                    StatType.Attack => AttackRange,
                    StatType.Defense => DefenseRange,
                    StatType.Speed => SpeedRange,
                    _ => throw new ArgumentOutOfRangeException(nameof(t), t, null)
                };
            }
        }
    }
}