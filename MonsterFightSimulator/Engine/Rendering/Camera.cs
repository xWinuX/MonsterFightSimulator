using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Camera
    {
        public Camera(Vector2Int size)
        {
            Size = size;
        }

        public void SetTarget(Vector2 target)
        {
            Position = new Vector2(target.X - (Size.X / 2), target.Y - (Size.Y / 2));
        }

        public Vector2 Position { get; set; } = Vector2.Zero;

        public Vector2Int Size { get; set; }
    }
}
