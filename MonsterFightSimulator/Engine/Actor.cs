using System;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public abstract class Actor : GameObject
    {
        public override void Update() { Sprite?.Update(Game.DeltaTime); }

        public void GameQuit() { Game.Quit = true; }

        public override void Render() { RenderSelf(); }

        protected void RenderSelf()
        {
            if (Sprite != null) { Game.Renderer.RenderOn(Transform.Position, Sprite); }
        }

        public void RenderSpriteAt(Vector2Int position, SpriteData spriteData) { Game.Renderer.RenderOn(position, new Sprite(spriteData)); }

        public void RenderSpriteAt(Vector2Int position, SpriteData spriteData, float frameIndex)
        {
            Sprite sprite = new Sprite(spriteData) {FrameIndex = frameIndex};
            Game.Renderer.RenderOn(position, sprite);
        }

        public string[] StringToTexture(string str)
        {
            return new[] {str};
        }
        
        public void RenderStringAt(Vector2Int position, string[] texture) { Game.Renderer.RenderOn(position, new SimpleTexture(texture)); }

        public bool InputDown(ConsoleKey key) { return Game.PressedKeys.Contains(key); }
    }
}