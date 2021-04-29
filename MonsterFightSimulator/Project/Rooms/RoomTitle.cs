using System;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomTitle : Room 
    {
        public override void Setup()
        {
            Console.WriteLine("AHGGGGGGGGGGGGGGGGG" + DateTime.Now);
            AddGameObject<ActorTitle>(1, Game.Camera.Size/2 + Vector2Int.Up * 6);
        }
    }
}