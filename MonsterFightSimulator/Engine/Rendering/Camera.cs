using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Camera
    {
        public Camera(Vector2Int size)
        {
            Size = size;
        }

        public Vector2Int Position { get; set; } = new Vector2Int(0, 0);

        public Vector2Int Size { get; set; }
    }
}
