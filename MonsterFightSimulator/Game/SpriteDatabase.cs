using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Game
{
    public class SpriteDatabase
    {
        public static readonly SpriteData SprTest = new SpriteData(
            new string[2][] {   new string[2] {     "aa",
                                                    "aa"},

                                new string[2] {     "AA",
                                                    "AA"}
            },
            3f
        );        
        public static readonly SpriteData SprTest2 = new SpriteData(
            new string[1][] { new string[2] {   "MMMMMMMMMM",
                                                "MMMMMMMMMM"} },
            1f
        );
        
    }
}
