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
        
        protected override void Setup()
        {
            
        }
    }
}