using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SimpleTexture : IRenderable
    {
        public SimpleTexture(string[] texture) { Texture = texture; }

        public SimpleTexture(string[] texture, Vector2Int origin) : this(texture) { Origin = origin; }

        public string[] Texture { get; }

        public Vector2Int Origin { get; } = Vector2Int.Zero;
    }
}