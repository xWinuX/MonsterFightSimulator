﻿using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Project
{
    public static class SpriteDatabase
    {
        private static readonly SpriteData DataSprTest = new SpriteData(3f, new[]
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
        public static Sprite SprTest => new Sprite(DataSprTest);

        private static readonly SpriteData DataSprTest2 = new SpriteData(1f, new[]
        {
            new[]
            {
                "MMM____MMM",
                "MMM____MMM"
            }
        });

        public static Sprite SprTest2 => new Sprite(DataSprTest2);
    }
}