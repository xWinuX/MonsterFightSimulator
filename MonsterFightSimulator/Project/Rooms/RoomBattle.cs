using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomBattle : Room
    {
        public override void Setup() { AddGameObject<ActorBattleManager>(0, Vector2Int.Zero); }
    }
}