namespace MonsterFightSimulator.Engine.Rendering
{
    public class SpriteData
    {
        public SpriteData(string[][] frames, float frameSpeed)
        {
            Frames      = frames;
            FrameSpeed  = frameSpeed;
            FrameCount  = frames.GetLength(0);
        }

        public float FrameSpeed { get; private set; }
        public int FrameCount { get; private set; }
        public string[][] Frames { get; private set; }
    }
}
