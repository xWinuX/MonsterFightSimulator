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
            SetWindowSize(windowSize);
        }

        private RenderSurface _applicationSurface = new RenderSurface(Vector2Int.Zero);

        private Camera _camera;
        
        private Vector2Int _windowSize;

        public void AssignCamera(Camera camera)
        {
            _camera = camera;
            RenderSurface newApplicationSurface = new RenderSurface(_camera.Size);
            newApplicationSurface.RenderOn(Vector2Int.Zero, _applicationSurface);
            _applicationSurface = newApplicationSurface;

        }

        public void SetWindowSize(Vector2Int windowSize)
        {
            _windowSize = windowSize;
            Console.SetWindowSize(_windowSize.X, _windowSize.Y);    
        }
        
        public void RenderOn(Vector2Int position, IRenderable renderable)
        {
            _applicationSurface.RenderOn(position - (Vector2Int)_camera.Position - renderable.Origin, renderable);
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
