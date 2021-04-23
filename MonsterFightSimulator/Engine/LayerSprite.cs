using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class LayerSprite : GameObject
    {
        public LayerSprite(SpriteData spriteData, Vector2Int position)
        {
            _spriteInstance = new SpriteInstance(spriteData);
            Transform.Position = position;
        }        

        public LayerSprite(Sprite sprite, Vector2Int position)
        {
            _spriteInstance = new SpriteInstance(sprite);
            Transform.Position = position;
        }

        private readonly SpriteInstance _spriteInstance;

        public override void Update(float deltaTime) { _spriteInstance.Update(deltaTime); }

        public override void Render() { _spriteInstance.RenderAt(Transform.Position); }
    }
}
