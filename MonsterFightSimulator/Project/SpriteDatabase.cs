using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Project
{
    public static class SpriteDatabase
    {
        private static readonly SpriteData DataSprSelector = new SpriteData(1f, OriginHelper.Preset.TopRight, new[]
        {
            new[] {"=>"}
        });

        private static readonly SpriteData DataSprHealthBar = new SpriteData(1f, OriginHelper.Preset.MiddleCenter, new[]
        {
            new[]
            {
                "+---------------+",
                "|:::::::::::::::|",
                "+---------------+"
            }
        });

        private static readonly SpriteData DataSprRain = new SpriteData(1f, OriginHelper.Preset.MiddleCenter, new[]
        {
            new[]
            {
                "/",
            }
        });        
        
        private static readonly SpriteData DataSprControls = new SpriteData(1f, OriginHelper.Preset.TopLeft, new[]
        {
            new[]
            {
                "  ^                   ",
                "< v >  Move Cursor    ",
                "                      ",
                " Enter                ",
                " <--'  Confirm/Select "
            }
        });

        private static readonly SpriteData DataSprTitle = new SpriteData(0f, OriginHelper.Preset.MiddleCenter, new[]
        {
            new[] // Generated using https://patorjk.com/software/taag/
            {
                ",-.-.&&&&&&&&&&&&&&&|&&&&&&&&&&&&&&&&&&,---.o&&&&&|&&&&|&&&&",
                "|&|&|,---.,---.,---.|---&,---.,---.&&&&|__.&.,---.|---.|---&",
                "|&|&||&&&||&&&|`---.|&&&&|---'|&&&&&&&&|&&&&||&&&||&&&||&&&&",
                "`&'&'`---'`&&&'`---'`---'`---'`&&&&&&&&`&&&&``---|`&&&'`---'",
                "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&`---'&&&&&&&&&&",
                "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&",
                "&&&&&&&&&&&,---.o&&&&&&&&&&|&&&&&&&&&|&&&&&&&&&&&&&&&&&&&&&&",
                "&&&&&&&&&&&`---..,-.-..&&&.|&&&&,---.|---&,---.,---.&&&&&&&&",
                "&&&&&&&&&&&&&&&|||&|&||&&&||&&&&,---||&&&&|&&&||&&&&&&&&&&&&",
                "&&&&&&&&&&&`---'``&'&'`---'`---'`---'`---'`---'`&&&&&&&&&&&&",
                "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&"
            }
        });

        public static Sprite SprHealthBar => new Sprite(DataSprHealthBar);
        public static Sprite SprRain => new Sprite(DataSprRain);
        public static Sprite SprControls => new Sprite(DataSprControls);
        public static Sprite SprSelector => new Sprite(DataSprSelector);
        public static Sprite SprTitle => new Sprite(DataSprTitle);
    }
}