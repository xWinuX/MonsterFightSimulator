using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SpriteData
    {
        public SpriteData(float frameSpeed, OriginHelper.Preset preset, string[][] frames) : this(frameSpeed, frames)
        {
            Origin = OriginHelper.CalculateOrigin(Size, preset);
        }

        public SpriteData(float frameSpeed, OriginHelper.AxisX axisX, OriginHelper.AxisY axisY, string[][] frames) : this(frameSpeed, frames)
        {
            Origin = OriginHelper.CalculateOrigin(Size, axisX, axisY);
        }

        public SpriteData(float frameSpeed, string[][] frames)
        {
            Frames     = frames;
            FrameSpeed = frameSpeed;
            FrameCount = frames.GetLength(0);

            Size = CalculateMaxSize();
        }

        public int FrameCount { get; }
        public string[][] Frames { get; }

        public float FrameSpeed { get; }
        public Vector2Int Origin { get; } = Vector2Int.Zero;
        public Vector2Int Size { get; }

        private Vector2Int CalculateMaxSize()
        {
            Vector2Int size = Vector2Int.Zero;
            foreach (string[] frame in Frames)
            {
                if (frame.Length > size.Y) { size.Y = frame.Length; }

                foreach (string line in frame)
                {
                    if (line.Length > size.X) { size.X = line.Length; }
                }
            }

            return size;
        }
    }
}