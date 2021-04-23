using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SimpleTexture : IRenderable
    {
        public SimpleTexture(string[] texture) { Texture = texture; }

        public string[] Texture {get; set;}

        public Vector2Int Origin { get; set; } = new Vector2Int(0, 0);
    }
}
