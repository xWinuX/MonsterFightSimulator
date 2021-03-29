using System;

using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Sprite : IRenderable
    {
        public Sprite(SpriteData spriteData) {_spriteData = spriteData;}

        public string[] Texture => _spriteData.Frames[(int)Math.Floor(FrameIndex)];

        public float FrameSpeed => _spriteData.FrameSpeed;

        public float FrameIndex
        {
            get => _frameIndex;
            set => _frameIndex = MyMathF.Wrap(value, 0, _spriteData.FrameCount);
        }
        private float _frameIndex = 0; // Private member for proprty

        private readonly SpriteData _spriteData;
    }
}
