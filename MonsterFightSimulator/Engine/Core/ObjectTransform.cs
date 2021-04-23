namespace MonsterFightSimulator.Engine.Core
{
    public class ObjectTransform
    {
        public ObjectTransform() { }
        public ObjectTransform(Vector2Int position) { Position = position; }
        
        public Vector2Int Position { get; set; } = Vector2Int.Zero;
    }
}