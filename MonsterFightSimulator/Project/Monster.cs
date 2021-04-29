namespace MonsterFightSimulator.Project
{
    public class Monster
    {
        public Monster(string name, Race race, Stats stats)
        {
            Name  = name;
            Race  = race;
            Stats = stats;
        }

        public Stats Stats { get; }

        public string Name { get; }

        public Race Race { get; }
    }
}