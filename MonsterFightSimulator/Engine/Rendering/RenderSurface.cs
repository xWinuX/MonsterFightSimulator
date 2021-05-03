using System.Text;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class RenderSurface : IRenderable
    {
        public RenderSurface(Vector2Int size) { Resize(size); }

        public Vector2Int Size { get => _size; set => Resize(value); }
        private Vector2Int _size = Vector2Int.Zero;

        public string[] Texture { get; private set; }

        public Vector2Int Origin { get; } = Vector2Int.Zero;

        public void RenderOn(Vector2Int position, IRenderable renderable)
        {
            // Get height of renderable
            int height = renderable.Texture.GetLength(0);

            // If renderable is out of view return out of function
            if (position.Y <= -height) { return; }

            // Render each line of the image
            Vector2Int finalPosition = Vector2Int.Zero;
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
                if (finalPosition.Y < 0) { continue; } // Top

                if (finalPosition.Y >= Size.Y) { break; } // Bottom (stops future lines from being rendered)

                // Clamp line length (Left)
                int renderableLineOffset = 0;
                while (finalPosition.X + renderableLineOffset < 0) { renderableLineOffset++; }

                finalPosition.X += renderableLineOffset;

                // Clamp line length (Right)
                int renderableClampedLineLength = renderableLine.Length;
                while (finalPosition.X + renderableClampedLineLength > Size.X) { renderableClampedLineLength--; }

                // Clamp image (if needed)
                int    diff      = renderableLine.Length - renderableClampedLineLength;
                string finalLine = (diff == 0 ? renderableLine : renderableLine.Remove(renderableLine.Length - diff)).Remove(0, renderableLineOffset);

                // Apply Transparency
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < finalLine.Length; i++)
                {
                    // If current letter is the transparency character replace it with the current letter that is at the same position
                    char letter = finalLine[i];
                    if (letter == Renderer.TransparentChar) { stringBuilder.Append(Texture[finalPosition.Y].Substring(finalPosition.X + i, 1)); }
                    else { stringBuilder.Append(letter); }
                }

                finalLine = stringBuilder.ToString();

                // Remove old characters
                Texture[finalPosition.Y] = Texture[finalPosition.Y].Remove(finalPosition.X, renderableClampedLineLength - renderableLineOffset);

                // Add new characters
                Texture[finalPosition.Y] = Texture[finalPosition.Y].Insert(finalPosition.X, finalLine);
            }
        }

        public void Clear(char fill = Renderer.Transparency)
        {
            for (int y = 0; y < Size.Y; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < Size.X; x++) { line.Append(fill); }

                Texture[y] = line.ToString();
            }
        }

        private void Resize(Vector2Int size)
        {
            _size   = size;
            Texture = new string[Size.Y];

            Clear();
        }
    }
}