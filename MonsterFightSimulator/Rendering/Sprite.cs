using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterFightSimulator.Core;

namespace MonsterFightSimulator.Rendering
{
    public class Sprite : IRenderable
    {
        public Sprite(string[][] frames, float frameSpeed)
        {
            _frames = frames;
            FrameSpeed = frameSpeed;

            FrameCount = frames.GetLength(0);

            Texture  = FrameCurrent;
        }


        public string[] Texture { get; set; }

        public float FrameSpeed { get; set; }
        public int FrameCount { get; private set; }
        public string[] FrameCurrent => _frames[Convert.ToInt32(MathF.Floor(_frameIndex))];
        public float FrameIndex 
        {
            get => _frameIndex;
            set => _frameIndex = MyMathF.Wrap(value, 0, FrameCount);
        }

        private string[][] _frames;
        private float _frameIndex = 0;


        public void Update(float deltaTime)
        {
            FrameIndex += FrameSpeed * deltaTime;
            Texture = FrameCurrent;
        }
    }
}
