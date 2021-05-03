using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterFightSimulator.Project.Classes
{
    public class Race
    {
        static Race()
        {
            List = new List<Race>();

            Goblin = new Race("Goblin");

            Troll = new Race("Troll");

            Orc = new Race("Orc");
        }

        private Race(string name)
        {
            Name = name;
            List.Add(this);
        }

        public static Race Goblin { get; }
        public static Race Troll { get; }
        public static Race Orc { get; }

        public static List<Race> List { get; }
        public string Name { get; }

        public static string[] GetNamesFromExisting() { return List.Select(race => race.Name).ToArray(); }

        public static Race GetRandomFromExisting(Random random) { return List[random.Next(0, List.Count - 1)]; }
    }
}