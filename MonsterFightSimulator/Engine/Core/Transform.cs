namespace MonsterFightSimulator.Engine.Core
{
    public class Transform
    {
        public Transform() { }
        public Transform(Vector2 position) { Position = position; }
        public Vector2 Position { get; set; } = Vector2.Zero;
    }
}