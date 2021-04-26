using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SimpleTexture : IRenderable
    {
        public SimpleTexture(string[] texture)
        {
            Texture = texture;
        }

        public string[] Texture { get; }

        public Vector2Int Origin { get; } = Vector2Int.Zero;
    }
}