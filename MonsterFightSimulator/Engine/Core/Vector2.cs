namespace MonsterFightSimulator.Engine.Core
{
    public struct Vector2
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);
        public static Vector2 Down => new Vector2(0, 1);
        public static Vector2 Up => new Vector2(0, -1);
        public static Vector2 Right => new Vector2(1, 0);
        public static Vector2 Left => new Vector2(-1, 0);

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.X, -a.Y);

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.X * b.X, a.Y * b.Y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.X / b.X, a.Y / b.Y);

        public static Vector2 operator +(Vector2 a, float b) => new Vector2(a.X + b, a.Y + b);
        public static Vector2 operator -(Vector2 a, float b) => new Vector2(a.X - b, a.Y - b);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.X * b, a.Y * b);
        public static Vector2 operator /(Vector2 a, float b) => new Vector2(a.X / b, a.Y / b);        
        
        
        public static Vector2 operator +(float a, Vector2 b) => new Vector2(b.X + a, b.Y + a);
        public static Vector2 operator -(float a, Vector2 b) => new Vector2(b.X - a, b.Y - a);
        public static Vector2 operator *(float a, Vector2 b) => new Vector2(b.X * a, b.Y * a);
        public static Vector2 operator /(float a, Vector2 b) => new Vector2(b.X / a, b.Y / a);

        public static implicit operator Vector2(Vector2Int v) => new Vector2(v.X, v.Y);
    }
}