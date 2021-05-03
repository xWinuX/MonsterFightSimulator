using System.Collections.Generic;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Classes;
using MonsterFightSimulator.Project.Rooms;

namespace MonsterFightSimulator.Project
{
    public class MonsterFightGame : Game
    {
        // Persistent Across Rooms
        public static List<MonsterPrototype> MonsterPrototypes;

        public MonsterFightGame(Vector2Int gameSize) : base(gameSize) { RoomGoto<RoomTitle>(); }
    }
}