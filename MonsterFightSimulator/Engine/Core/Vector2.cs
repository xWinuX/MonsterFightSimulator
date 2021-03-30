namespace MonsterFightSimulator.Engine.Core
{
    public class Vector2Int
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Add(Vector2Int add)
        {
            X += add.X;
            Y += add.Y;

        }      
        public void Sub(Vector2Int add)
        {
            X -= add.X;
            Y -= add.Y;
        }

        public static Vector2Int Add(Vector2Int a, Vector2Int b) { return new Vector2Int(a.X + b.X, a.Y + b.Y); }
        public static Vector2Int Sub(Vector2Int a, Vector2Int b) { return new Vector2Int(a.X - b.X, a.Y - b.Y); }
    }
}
