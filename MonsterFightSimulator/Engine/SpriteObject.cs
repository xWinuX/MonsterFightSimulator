using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class SpriteObject : GameObject
    {
        public SpriteObject(Vector2Int position, SpriteData spriteData)
        {
            Sprite             = new Sprite(spriteData);
            Transform.Position = position;
        }

        public SpriteObject(Vector2Int position, Sprite sprite)
        {
            Sprite             = sprite;
            Transform.Position = position;
        }

        public override void Update() { Sprite.Update(Game.DeltaTime); }

        public override void Render() { Game.Renderer.RenderOn(Transform.Position, Sprite); }
    }
}