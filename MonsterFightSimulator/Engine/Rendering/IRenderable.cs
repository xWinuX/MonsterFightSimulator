using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public interface IRenderable
    {
        Vector2Int Origin { get; }
        string[] Texture { get; }
    }
}