﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFightSimulator.Core
{
    public static class MyMathF
    {
        // Source: https://stackoverflow.com/questions/14415753/wrap-value-into-range-min-max-without-division 
        public static float Wrap(float value, float min, float max)
        {
            return (((value - min) % (max - min)) + (max - min)) % (max - min) + min;
        }
    }
}

