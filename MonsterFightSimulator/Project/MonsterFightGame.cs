using System;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Rooms;


namespace MonsterFightSimulator.Project
{
    public class MonsterFightGame : Game
    {
        public MonsterFightGame(Vector2Int gameSize) : base(gameSize)
        {
            RoomGoto<RoomTitle>();
        }

        public static Race Orc;
        public static Race Troll;
        public static Race Goblin;

        public static Random Random = new Random();

        protected override void Setup()
        {
            Orc    = new Race("Ork");
            Troll  = new Race("Troll");
            Goblin = new Race("Goblin");
        }
    }
}