using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Camera
    {
        public Camera(Vector2Int size)
        {
            Size = size;
        }

        public void SetTarget(Vector2Int target)
        {
            Position = new Vector2Int(target.X - (Size.X / 2), target.Y - (Size.Y / 2));
        }

        public Vector2Int Position { get; set; } = new Vector2Int(0, 0);

        public Vector2Int Size { get; set; }
    }
}
