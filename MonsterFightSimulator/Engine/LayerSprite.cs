using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class LayerSprite : ILayerItem, IHasPosition
    {
        public LayerSprite(SpriteData spriteData, Vector2Int position)
        {
            _sprite = new Sprite(spriteData);
            Position = position;
        }

        private readonly Sprite _sprite;

        public Vector2Int Position { get; set; }

        public void Update(float deltaTime)
        {
            _sprite.Update(deltaTime);
        }

        public void Render()
        {
            Program.CurrentSurface.RenderOn(Position, _sprite);
        }
    }
}
