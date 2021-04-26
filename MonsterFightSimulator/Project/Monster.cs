namespace MonsterFightSimulator.Project
{
    public class Monster
    {
        public Monster(string name, Race race)
        {
            Name = name;
            Race = race;
        }

        public string Name { get; set; }

        public string RaceName => Race.Name;

        protected Race Race { get; set; }
    }
}
