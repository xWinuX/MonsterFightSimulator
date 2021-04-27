using System.Linq;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SimpleTexture : IRenderable
    {
        public SimpleTexture(string[] texture) { Texture = texture; }

        public SimpleTexture(string[] texture, OriginHelper.AxisX axisX, OriginHelper.AxisY axisY) : this(texture)
        {
            Origin = OriginHelper.CalculateOrigin(GetSize(), axisX, axisY);
        }

        public SimpleTexture(string[] texture, OriginHelper.Preset preset) : this(texture)
        {
            Origin = OriginHelper.CalculateOrigin(GetSize(), preset);
        }

        public string[] Texture { get; }

        public Vector2Int Origin { get; } = Vector2Int.Zero;

        private Vector2Int GetSize()
        {
            Vector2Int size = Vector2Int.Zero;
            size.X = Texture.OrderByDescending(s => s.Length).First().Length;
            size.Y = Texture.Length;

            return size;
        }
    }
}