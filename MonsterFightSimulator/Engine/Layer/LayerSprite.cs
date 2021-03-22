using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class LayerSprite : ILayerItem, IHasPosition
    {
        public LayerSprite(SpriteData spriteData, Vector2Int position)
        {
            _spriteInstance = new SpriteInstance(spriteData);
            Position = position;
        }        

        public LayerSprite(Sprite sprite, Vector2Int position)
        {
            _spriteInstance = new SpriteInstance(sprite);
            Position = position;
        }

        public Vector2Int Position { get; set; }

        public void Update(float deltaTime) { _spriteInstance.Update(deltaTime); }

        public void Render() { _spriteInstance.RenderAt(Position); }

        private readonly SpriteInstance _spriteInstance;
    }
}
