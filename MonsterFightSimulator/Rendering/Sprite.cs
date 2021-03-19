using System;
using MonsterFightSimulator.Core;

namespace MonsterFightSimulator.Rendering
{
    public class Sprite : IRenderable
    {
        public Sprite(SpriteData spriteData)
        {
            _spriteData = spriteData;
        }

        public string[] Texture => _spriteData.Frames[Convert.ToInt32(Math.Floor(FrameIndex))];

        public float FrameIndex
        {
            get => _frameIndex;
            set => _frameIndex = MyMathF.Wrap(value, 0, _spriteData.FrameCount);
        }
        private float _frameIndex = 0; // Private member for proprty

        private readonly SpriteData _spriteData;
 
        public void Update(float deltaTime, float speedModifier = 1)
        {
            FrameIndex += (_spriteData.FrameSpeed * speedModifier) * deltaTime;
        }
    }
}
