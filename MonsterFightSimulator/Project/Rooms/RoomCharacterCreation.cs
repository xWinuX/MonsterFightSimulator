using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomCharacterCreation : Room
    {
        public override void Setup()
        {
            AddGameObject<ActorFighterCreateMenu>(1, Vector2Int.One * 5);

        }
    }
}