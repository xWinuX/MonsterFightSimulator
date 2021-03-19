namespace MonsterFightSimulator.Rendering
{
    public class SpriteData
    {
        public SpriteData(string[][] frames, float frameSpeed)
        {
            Frames      = frames;
            FrameSpeed  = frameSpeed;
            FrameCount  = frames.GetLength(0);
        }

        public float FrameSpeed { get; private set; } // Speed of animation (images per second)
        public int FrameCount { get; private set; } // Number of frames
        public string[][] Frames { get; private set; }
    }
}
