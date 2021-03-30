using System;

using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class Actor : GameObject
    {
        public Actor()
            : base() {}

        public virtual SpriteInstance SpriteInstance { get; set; } = null;

        public virtual void Start() {}

        public override void Update(float deltaTime) { if (SpriteInstance != null) { SpriteInstance.Update(deltaTime); } }

        protected void DestroySelf()
        {
            Program.LayerList.Remove(this);
        }

        public override void Render() { RenderSelf(); }

        protected void RenderSelf() { if (SpriteInstance != null) { SpriteInstance.RenderAt(Position); } }

        public static void RenderSpriteAt(Vector2Int position, SpriteData spriteData) { new SpriteInstance(spriteData).RenderAt(position); }
        public static void RenderSpriteAt(Vector2Int position, SpriteData spriteData, float frameIndex) { new SpriteInstance(spriteData).RenderAt(position, frameIndex); }
        public static void RenderStringAt(Vector2Int position, string[] texture) { Program.Renderer.RenderOn(position, new SimpleTexture(texture)); }

        public static bool InputDown(ConsoleKey key)
        {
            return Program.PressedKeys.Contains(key);
        }
    }
}
