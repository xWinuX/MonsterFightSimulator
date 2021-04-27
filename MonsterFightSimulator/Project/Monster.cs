namespace MonsterFightSimulator.Project
{
    public class Monster
    {
        public Monster(string name, Race race, MonsterStats monsterStats)
        {
            Name         = name;
            Race         = race;
            MonsterStats = monsterStats;
        }

        public MonsterStats MonsterStats { get; }

        public string Name { get; }

        public Race Race { get; }
    }
}