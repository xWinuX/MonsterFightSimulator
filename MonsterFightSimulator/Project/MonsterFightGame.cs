using System.Collections.Generic;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Rooms;

namespace MonsterFightSimulator.Project
{
    public class MonsterFightGame : Game
    {
        // Persistent Across Rooms
        public static List<MonsterPrototype> MonsterPrototypes;
        
        public MonsterFightGame(Vector2Int gameSize) : base(gameSize)
        {
            MonsterPrototypes = new List<MonsterPrototype>();
            MonsterPrototypes.Add(new MonsterPrototype()
            {
                Name = "Test1",
                Race =  Race.Goblin,
                Stats = new Stats(20, 1, 1, 10)
            });            
            MonsterPrototypes.Add(new MonsterPrototype()
            {
                Name = "Test2",
                Race =  Race.Orc,
                Stats = new Stats(40, 3, 3, 5)
            });
            //RoomGoto<RoomTitle>();
            RoomGoto<RoomBattle>();
        }
        
        protected override void Setup()
        {
            
        }
    }
}