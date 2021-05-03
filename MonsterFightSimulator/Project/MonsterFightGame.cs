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
            /* Debug
            MonsterPrototypes = new List<MonsterPrototype>();
            MonsterPrototypes.Add(new MonsterPrototype
            {
                Name  = "Goblino",
                Race  = Race.Goblin,
                Stats = new Stats(20, 20, 1, 5)
            });
            MonsterPrototypes.Add(new MonsterPrototype
            {
                Name  = "Orcino",
                Race  = Race.Orc,
                Stats = new Stats(40, 3, 3, 5)
            }); 
            RoomGoto<RoomBattle>(); */
            
            RoomGoto<RoomTitle>();
        }

        protected override void Setup() { }
    }
}