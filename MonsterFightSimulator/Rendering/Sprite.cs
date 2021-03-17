﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterFightSimulator.Core;

namespace MonsterFightSimulator.Rendering
{
    public class Sprite : IRenderable
    {
        public Sprite(char[][,] frames, float frameSpeed)
        {
            _frames = frames;
            FrameSpeed = frameSpeed;

            FrameSize = new Vector2<int>(frames[0].GetLength(0), frames[0].GetLength(1));
            FrameCount = frames.GetLength(0);
        }

        public float FrameSpeed { get; set; }
        public int FrameCount { get; private set; }
        public Vector2<int> FrameSize { get; private set; }
        public char[,] FrameCurrent => _frames[Convert.ToInt32(MathF.Floor(_frameIndex))];
        public float FrameIndex 
        {
            get => _frameIndex;
            set => _frameIndex = MyMathF.Wrap(value, 0, FrameCount);
        }

        private char[][,] _frames;

        private float _frameIndex = 0;

        public void Update(float deltaTime)
        {
            FrameIndex += FrameSpeed * deltaTime;
        }

        public void Render(RenderSurface renderSurface, Vector2<float> position)
        {
            throw new NotImplementedException();
        }
    }
}
