using MonsterFightSimulator.Engine.Core;
using System;

namespace MonsterFightSimulator.Engine.Rendering
{
    class Renderer
    {
        public Renderer(Vector2Int cameraViewSize, Vector2Int windowSize)
        {
            // Create camera and configure it
            Camera = new Camera(cameraViewSize);
            Camera.Size = cameraViewSize;

            // Create application surface and configure it
            _applicationSurface = new RenderSurface(cameraViewSize);
            _applicationSurface.Size = Camera.Size;

            // Set window size and apply it
            _windowSize = windowSize;
            Console.SetWindowSize(_windowSize.X, _windowSize.Y);
        }

        private Vector2Int _windowSize = new Vector2Int(20, 20);

        private RenderSurface _applicationSurface;

        public Camera Camera { get; private set; }

        public void RenderOn(Vector2Int position, IRenderable renderable)
        {
            _applicationSurface.RenderOn(Vector2Int.Sub(position, Camera.Position), renderable);
        }

        public void Prepare()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(_windowSize.X, _windowSize.Y);
            Console.SetCursorPosition(0, 0);
            _applicationSurface.Clear();
        }

        public void Display()
        {
            for (int i = 0; i < _applicationSurface.Texture.Length; i++) 
            { 
                //TODO: implement camera Size
                string line = _applicationSurface.Texture[i];
                if (i == _applicationSurface.Texture.Length - 1) { Console.Write(line); } // Check if it's last line, if true only write without new line (fixes jittering if windowSize == cameraSize)
                else { Console.WriteLine(line); } 
            }
        }
    }
}
