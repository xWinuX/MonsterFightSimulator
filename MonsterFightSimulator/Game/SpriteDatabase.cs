using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Game
{
    public static class SpriteDatabase
    {
        public static readonly SpriteData SprTest = new SpriteData(3f, new[]
        {
            new[]
            {
                " o ",
                "/O\\",
                " ^"
            },

            new[]
            {
                " o ",
                "|O|",
                " | "
            }
        });

        public static readonly SpriteData SprTest2 = new SpriteData(1f, new[]
        {
            new[]
            {
                "MMMMMMMMMM",
                "MMMMMMMMMM"
            }
        });
    }
}