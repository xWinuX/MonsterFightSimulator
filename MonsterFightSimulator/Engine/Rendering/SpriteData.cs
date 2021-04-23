using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SpriteData
    {
        public SpriteData(float frameSpeed, string[][] frames)
        {
            Frames      = frames;
            FrameSpeed  = frameSpeed;
            FrameCount  = frames.GetLength(0);

            foreach(string[] frame in Frames)
            {
                Vector2Int size = Vector2Int.Zero;
                if (frame.Length > Size.Y) { size.Y = frame.Length; }
                foreach (string line in frame)
                {
                    if (line.Length > Size.X) { size.X = line.Length; }
                }

                Size = size;
            }

            Origin   = new Vector2Int(Size.X / 2, Size.Y / 2);
        }

        public float FrameSpeed { get; private set; }
        public int FrameCount { get; private set; }
        public string[][] Frames { get; private set; }
        public Vector2Int Origin { get; private set; }
        public Vector2Int Size { get; private set; } = Vector2Int.Zero;
    }
}
