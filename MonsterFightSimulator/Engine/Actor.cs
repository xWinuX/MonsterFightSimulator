using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class Actor : ILayerItem, IHasPosition
    {
        public Vector2Int Position { get; set; } = new Vector2Int(0, 0);

        public virtual SpriteInstance SpriteInstance { get; set; } = null;

        public virtual void Start() {}

        public virtual void Update(float deltaTime) { if (SpriteInstance != null) { SpriteInstance.Update(deltaTime); } }

        public virtual void Render() { RenderSelf(); }

        protected void RenderSelf() { if (SpriteInstance != null) { SpriteInstance.RenderAt(Position); } }

        public static void RenderSpriteAt(Vector2Int position, SpriteData spriteData) { new SpriteInstance(spriteData).RenderAt(position); }
        public static void RenderSpriteAt(Vector2Int position, SpriteData spriteData, float frameIndex) { new SpriteInstance(spriteData).RenderAt(position, frameIndex); }
        public static void RenderStringAt(Vector2Int position, string[] texture) { Program.CurrentSurface.RenderOn(position, new SimpleTexture(texture)); }
    }
}
