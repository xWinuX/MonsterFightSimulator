using System;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class Sprite : IRenderable
    {
        public Sprite(SpriteData data) { Data = data; }

        public SpriteData Data { get; }

        public float FrameIndex { get => _frameIndex; set => _frameIndex = MyMathF.Wrap(value, 0, Data.FrameCount); }
        public float SpeedModifier { get; set; } = 1f;
        private float _frameIndex;

        public string[] Texture => Data.Frames[(int) Math.Floor(FrameIndex)];
        public Vector2Int Origin => Data.Origin;

        public void Update(float deltaTime) { FrameIndex += Data.FrameSpeed * SpeedModifier * deltaTime; }
    }
}