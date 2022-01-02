using System;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Renderer
    {
        public const char Transparency    = ' ';
        public const char TransparentChar = '&';

        public Renderer(Camera camera, Vector2Int windowSize)
        {
            AssignCamera(camera);
            _windowSize = windowSize;
            ApplyWindowSize();
        }

        private RenderSurface _applicationSurface = new RenderSurface(Vector2Int.Zero);

        private Camera _camera;

        private Vector2Int _previousConsoleSize;
        private Vector2Int _windowSize;

        private void AssignCamera(Camera camera)
        {
            _camera = camera;
            RenderSurface newApplicationSurface = new RenderSurface(_camera.Size);
            newApplicationSurface.RenderOn(Vector2Int.Zero, _applicationSurface);
            _applicationSurface = newApplicationSurface;
        }

        private void ApplyWindowSize()
        {
            try { Console.SetWindowSize(Math.Min(_windowSize.X, Console.LargestWindowWidth), Math.Min(_windowSize.Y, Console.LargestWindowHeight)); }
            catch { /* Ignored, this function sometimes throws errors if the user tries to resize the window (which they shouldn't in the first place) */ }
        }

        public void RenderOn(Vector2Int position, IRenderable renderable)
        {
            _applicationSurface.RenderOn(position - (Vector2Int) _camera.Position - renderable.Origin, renderable);
        }

        public void Prepare()
        {
            // Check if window was resized, if true clear it
            Vector2Int currentConsoleSize = new Vector2Int(Console.WindowWidth, Console.WindowHeight);
            if (currentConsoleSize.X != _previousConsoleSize.X || currentConsoleSize.Y != _previousConsoleSize.Y) { Console.Clear(); }

            // Prepare Cursor
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            
            // Clear application surface 
            _applicationSurface.Clear();
            
            // Save 
            _previousConsoleSize = new Vector2Int(Console.WindowWidth, Console.WindowHeight);
        }

        public void Display()
        {
            for (int i = 0; i < _applicationSurface.Texture.Length; i++)
            {
                string line = _applicationSurface.Texture[i];
                // Check if it's last line, if true only write without new line (fixes jittering if windowSize == cameraSize)
                if (i == _applicationSurface.Texture.Length - 1) { Console.Write(line); }
                else { Console.WriteLine(line); }
            }
        }
    }
}