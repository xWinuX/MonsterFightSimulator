namespace MonsterFightSimulator.Rendering
{
    public class SimpleTexture : IRenderable
    {
        public SimpleTexture(string[] texture) { Texture = texture; }

        public string[] Texture {get; set;}
    }
}
