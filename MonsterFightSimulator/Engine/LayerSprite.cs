using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class LayerSprite : GameObject
    {
        public LayerSprite(SpriteData spriteData, Vector2Int position) 
            : base()
        {
            _spriteInstance = new SpriteInstance(spriteData);
            Position = position;
        }        

        public LayerSprite(Sprite sprite, Vector2Int position) 
            : base()
        {
            _spriteInstance = new SpriteInstance(sprite);
            Position = position;
        }

        private readonly SpriteInstance _spriteInstance;

        public override void Update(float deltaTime) { _spriteInstance.Update(deltaTime); }

        public override void Render() { _spriteInstance.RenderAt(Position); }
    }
}
