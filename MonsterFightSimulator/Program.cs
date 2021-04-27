using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project;

namespace MonsterFightSimulator
{
    public static class Program
    {
        private static void Main() { new MonsterFightGame(new Vector2(80, 30)).Run(); }
    }
}