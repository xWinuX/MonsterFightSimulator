﻿namespace MonsterFightSimulator.Engine.Core
{
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
        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);
        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new Vector2Int(a.X * b.X, a.Y * b.Y);
        public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new Vector2Int(a.X / b.X, a.Y / b.Y);
    }
}
