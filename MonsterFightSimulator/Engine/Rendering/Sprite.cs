using System;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Sprite : IRenderable
    {
        public Sprite(SpriteData spriteData) { _spriteData = spriteData; }

        public string[] Texture => _spriteData.Frames[(int) Math.Floor(FrameIndex)];
        public Vector2Int Origin => _spriteData.Origin;
        public float SpeedModifier { get; set; } = 1f;

        public float FrameIndex { get => _frameIndex; set => _frameIndex = MyMathF.Wrap(value, 0, _spriteData.FrameCount); }
        private float _frameIndex;

        private readonly SpriteData _spriteData;
        
        public void Update(float deltaTime) { FrameIndex += _spriteData.FrameSpeed * SpeedModifier * deltaTime; }
    }
}