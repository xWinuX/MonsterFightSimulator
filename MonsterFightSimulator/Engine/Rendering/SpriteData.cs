using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public class SpriteData
    {
        public SpriteData(float frameSpeed, string[][] frames)
        {
            Frames     = frames;
            FrameSpeed = frameSpeed;
            FrameCount = frames.GetLength(0);
            
            Vector2Int size = Vector2Int.Zero;
            foreach (string[] frame in Frames)
            {
                if (frame.Length > size.Y) { size.Y = frame.Length; }

                foreach (string line in frame)
                {
                    if (line.Length > size.X) { size.X = line.Length; }
                }
            }

            Size   = size;
            Origin = new Vector2Int(Size.X / 2, Size.Y / 2);
        }

        public float FrameSpeed { get; }
        public int FrameCount { get; }
        public string[][] Frames { get; }
        public Vector2Int Origin { get; }
        public Vector2Int Size { get; } = Vector2Int.Zero;
    }
}