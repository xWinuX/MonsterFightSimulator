namespace MonsterFightSimulator.Project
{
    public class Stats : IHealth, IStats
    {
        public Stats(StatsRangeProfile rangeProfile)
        {
            RangeProfile = rangeProfile;
            
            HealthMax = RangeProfile.HealthRange.MinValue;
            Health    = HealthMax;
            Attack    = RangeProfile.AttackRange.MinValue;
            Defense   = RangeProfile.DefenseRange.MinValue;
            Speed     = RangeProfile.SpeedRange.MinValue;
        }

        public float Health { get; set; }
        public float HealthMax { get; set; }
        public float Attack { get; set; }
        public float Defense { get; set; }
        public float Speed { get; set; }

        public StatsRangeProfile RangeProfile { get; }
    }
}