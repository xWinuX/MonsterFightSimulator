using System;

namespace MonsterFightSimulator.Engine.Core
{
    /*
     * This should be used for Rendering stuff since the console only works with ints
     * Another use is for values that don't need to be changed smoothly or don't change at all like the size of sprites or the size of the camera
     * For anything that needs to be moved smoothly like positions use Vector2, it will get automatically converted to a Vector2Int with rounding (2.4 => 2 | 2.6 => 3)
     */
    public struct Vector2Int
    {
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);
        public static Vector2Int Down => new Vector2Int(0, 1);
        public static Vector2Int Up => new Vector2Int(0, -1);
        public static Vector2Int Right => new Vector2Int(1, 0);
        public static Vector2Int Left => new Vector2Int(-1, 0);

        public static Vector2Int operator -(Vector2Int a) => new Vector2Int(-a.X, -a.Y);
        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);
        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new Vector2Int(a.X * b.X, a.Y * b.Y);
        public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new Vector2Int(a.X / b.X, a.Y / b.Y);
        public static Vector2Int operator +(Vector2Int a, int b) => new Vector2Int(a.X + b, a.Y + b);
        public static Vector2Int operator -(Vector2Int a, int b) => new Vector2Int(a.X - b, a.Y - b);
        public static Vector2Int operator *(Vector2Int a, int b) => new Vector2Int(a.X * b, a.Y * b);
        public static Vector2Int operator /(Vector2Int a, int b) => new Vector2Int(a.X / b, a.Y / b);
        public static Vector2Int operator +(int a, Vector2Int b) => new Vector2Int(b.X + a, b.Y + a);
        public static Vector2Int operator -(int a, Vector2Int b) => new Vector2Int(b.X - a, b.Y - a);
        public static Vector2Int operator *(int a, Vector2Int b) => new Vector2Int(b.X * a, b.Y * a);
        public static Vector2Int operator /(int a, Vector2Int b) => new Vector2Int(b.X / a, b.Y / a);

        public static implicit operator Vector2Int(Vector2 v) => new Vector2Int((int) MathF.Round(v.X), (int) MathF.Round(v.Y));
    }
}