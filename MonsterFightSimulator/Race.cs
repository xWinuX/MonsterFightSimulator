﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFightSimulator
{
    public class Race
    { 
        public Race(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
    }
}
