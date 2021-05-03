using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomCharacterCreation : Room
    {
        public override void Setup() { AddGameObject<ActorFighterCreateMenu>(1, Game.Camera.Size / 2); }
    }
}