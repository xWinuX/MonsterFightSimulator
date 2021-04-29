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
        
        public Range HealthRange  {get;}
        public Range AttackRange  {get;}
        public Range DefenseRange {get;}
        public Range SpeedRange   {get;}
    }
}