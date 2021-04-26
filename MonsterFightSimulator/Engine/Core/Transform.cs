namespace MonsterFightSimulator.Engine.Core
{
    public class Transform
    {
        public Transform() { }
        public Transform(Vector2Int position) { Position = position; }
        public Vector2Int Position { get; set; } = Vector2Int.Zero;
    }
}