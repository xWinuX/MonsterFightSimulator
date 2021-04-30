using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomBattle : Room
    {
        public override void Setup()
        {
            AddGameObject<ActorBattleManager>(0, Vector2Int.Zero);
            ActorTextBox textBox = AddGameObject<ActorTextBox>(1, new Vector2Int(Game.Camera.Size.X/2, Game.Camera.Size.Y/2));
            textBox.Size = new Vector2Int(Game.Camera.Size.X-6, (Game.Camera.Size.Y / 2)-1);
        }
    }
}