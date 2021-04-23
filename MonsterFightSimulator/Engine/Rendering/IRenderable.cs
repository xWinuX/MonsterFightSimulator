using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public interface IRenderable
    {
        string[] Texture { get; }

        Vector2Int Origin { get; }
    }
}
