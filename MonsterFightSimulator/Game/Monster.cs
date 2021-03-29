using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFightSimulator
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
