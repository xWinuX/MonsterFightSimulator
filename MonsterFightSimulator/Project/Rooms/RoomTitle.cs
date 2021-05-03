using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomTitle : Room
    {
        public override void Setup() { AddGameObject<ActorTitle>(1, Game.Camera.Size / 2 + Vector2Int.Up * 6); }
    }
}