using System.Text;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class RenderSurface : IRenderable
    {
        private const char _defaultWhitespaceCharacter = ' ';

        public RenderSurface(Vector2Int size) { Resize(size); }

        public string[] Texture { get; private set; }

        public Vector2Int Size
        {
            get => _size;
            set => Resize(value);
        }
        private Vector2Int _size = new Vector2Int(0, 0);

        private void Resize(Vector2Int size)
        {
            _size = size;
            Texture = new string[Size.Y];

            Clear();
        }

        public void RenderOn(Vector2Int position, IRenderable renderable)
        {
            // Get height of renderable
            int height = renderable.Texture.GetLength(0);

            // If renderable is out of view return out of function
            if (position.Y <= -height) { return; }

            // Render each line of the image
            Vector2Int finalPosition = new Vector2Int(0, 0);
            for (int y = 0; y < height; y++)
            {
                // Calculate Positions
                finalPosition.X = position.X;
                finalPosition.Y = y + position.Y;

                // Cache current renderable line
                string renderableLine = renderable.Texture[y];

                // Check if position is completely out of view, if true exit whole rendering process
                if (finalPosition.X >= Size.X || finalPosition.X + renderableLine.Length < 0) { break; }

                // Cutoff lines
                if (finalPosition.Y < 0) { continue; }      // Top
                if (finalPosition.Y >= Size.Y) { break; }   // Bottom (stops future lines from being rendered)

                // Clamp line length (Left)
                int renderableLineOffset = 0;
                while (finalPosition.X + renderableLineOffset < 0) { renderableLineOffset++; }
                finalPosition.X += renderableLineOffset;

                // Clamp line length (Right)
                int renderableClampedLineLength = renderableLine.Length;
                while (finalPosition.X + renderableClampedLineLength > Size.X) { renderableClampedLineLength--;}

                // Remove old characters
                Texture[finalPosition.Y] = Texture[finalPosition.Y].Remove(finalPosition.X, renderableClampedLineLength - renderableLineOffset);

                // Add new characters and clamp image (if needed)
                int diff = renderableLine.Length - renderableClampedLineLength;
                string finalLine = diff == 0 ? renderableLine : renderableLine.Remove(renderableLine.Length - diff);
                Texture[finalPosition.Y] = Texture[finalPosition.Y].Insert(finalPosition.X, finalLine.Remove(0, renderableLineOffset));
            }  
        }

        public void Clear(char fill = _defaultWhitespaceCharacter)
        {
            for (int y = 0; y < Size.Y; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < Size.X; x++) { line.Append(fill); }
                Texture[y] = line.ToString();
            }
        }
    }
}
