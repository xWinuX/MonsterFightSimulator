using System;

namespace MonsterFightSimulator.Engine.Core
{
    public static class MyMathF
    {
        // Source: https://stackoverflow.com/questions/14415753/wrap-value-into-range-min-max-without-division 
        public static float Wrap(float value, float min, float max) => ((value - min) % (max - min) + (max - min)) % (max - min) + min;

        public static float Wrap(float value, Range range) => Wrap(value, range.MinValue, range.MaxValue + 1);

        public static float Clamp(float value, Range range) => Math.Clamp(value, range.MinValue, range.MaxValue);
    }
}