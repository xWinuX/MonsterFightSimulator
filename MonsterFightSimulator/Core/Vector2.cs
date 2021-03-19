namespace MonsterFightSimulator.Core
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

        public void Add (Vector2Int add)
        {
            X += add.X;
            Y += add.Y;
        }
    }
}
