using System;

using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class Actor : GameObject
    {
        public Actor() { }
        public Actor(Vector2Int position) { Transform.Position = position; }
        
        public virtual SpriteInstance SpriteInstance { get; set; } = null;

        public override void Update(float deltaTime) { if (SpriteInstance != null) { SpriteInstance.Update(deltaTime); } }

        public void GameQuit() { Program.Quit = true; }

        public override void Render() { RenderSelf(); }

        protected void RenderSelf() { if (SpriteInstance != null) { SpriteInstance.RenderAt(Transform.Position); } }

        public static void RenderSpriteAt(Vector2Int position, SpriteData spriteData) { new SpriteInstance(spriteData).RenderAt(position); }
        public static void RenderSpriteAt(Vector2Int position, SpriteData spriteData, float frameIndex) { new SpriteInstance(spriteData).RenderAt(position, frameIndex); }
        public static void RenderStringAt(Vector2Int position, string[] texture) { Program.Renderer.RenderOn(position, new SimpleTexture(texture)); }

        public static bool InputDown(ConsoleKey key)
        {
            return Program.PressedKeys.Contains(key);
        }
    }
}
