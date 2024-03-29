﻿using System;

namespace MonsterFightSimulator.Engine.Core
{
    public struct Range
    {
        public Range(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public float MinValue { get; }
        public float MaxValue { get; }

        public readonly float GetRandomBetween(Random random) => MinValue + (MaxValue - MinValue) * (float) random.NextDouble();

        public override string ToString() => MinValue + "-" + MaxValue;
    }
}