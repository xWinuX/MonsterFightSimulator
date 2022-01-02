using System;
using System.Collections.Generic;
using System.Linq;
using Range = MonsterFightSimulator.Engine.Core.Range;

namespace MonsterFightSimulator.Project.Classes
{
    public class Race
    {
        static Race()
        {
            List = new List<Race>();

            Goblin = new Race("Goblin", new StatsRangeProfile(
                new Range(1, 20),
                new Range(2, 5),
                new Range(0, 1),
                new Range(5, 10)
            ));

            Troll = new Race("Troll", new StatsRangeProfile(
                new Range(1, 30),
                new Range(3, 8),
                new Range(1, 3),
                new Range(3, 6)
            ));

            Orc = new Race("Orc", new StatsRangeProfile(
                new Range(1, 50),
                new Range(1, 4),
                new Range(4, 8),
                new Range(1, 3)
            ));
        }

        private Race(string name, StatsRangeProfile rangeProfile)
        {
            Name         = name;
            RangeProfile = rangeProfile;
            List.Add(this);
        }

        public static Race Goblin { get; }
        public static Race Troll { get; }
        public static Race Orc { get; }

        public static List<Race> List { get; }
        public string Name { get; }

        public StatsRangeProfile RangeProfile { get; }

        public static string[] GetNamesFromExisting() => List.Select(race => race.Name).ToArray();

        public static Race GetRandomFromExisting(Random random) => List[random.Next(0, List.Count - 1)];
    }
}