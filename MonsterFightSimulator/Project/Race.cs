using System;
using System.Collections.Generic;

namespace MonsterFightSimulator.Project
{
    public class Race
    {
        public Race(string name)
        {
            Name = name;
            List.Add(this);
        }
        
        public string Name { get; }

        public static List<Race> List = new List<Race>();

        public static string[] GetNamesFromExisting()
        {
            string[] str = new string[List.Count];
            for (int i = 0; i < List.Count; i++)
            {
                Race race = List[i];
                str[i] = race.Name;
            }

            return str;
        }

        public static Race GetRandomFromExisting() { return GetRandomFromExisting(new Random()); }
        
        public static Race GetRandomFromExisting(Random random) { return List[random.Next(0, List.Count - 1)]; }
    }
    
}