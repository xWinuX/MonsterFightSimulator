using System;
using MonsterFightSimulator.Rendering;
using MonsterFightSimulator.Core;

namespace MonsterFightSimulator.Engine
{
    public class SpriteInstance : IRenderable
    {
        public SpriteInstance(Sprite sprite) { _sprite = sprite; }
        public SpriteInstance(SpriteData spriteData) { _sprite = new Sprite(spriteData); }

        public float SpeedModifier { get; set; } = 1f;

        public string[] Texture => _sprite.Texture;

        public float FrameIndex => _sprite.FrameIndex;

        public void Update(float deltaTime) { _sprite.FrameIndex += _sprite.FrameSpeed * SpeedModifier * deltaTime; }
        
        public void RenderAt(Vector2Int position) { Program.CurrentSurface.RenderOn(position, _sprite); }            
        
        public void RenderAt(Vector2Int position, float frameIndex) 
        {
            SpeedModifier = 0f;
            _sprite.FrameIndex = (float)frameIndex;
            Program.CurrentSurface.RenderOn(position, _sprite); 
        }            

        public Sprite _sprite;
    }
}
