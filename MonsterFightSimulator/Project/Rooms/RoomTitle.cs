using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project.Rooms
{
    public class RoomTitle : Room
    {
        public override void Setup()
        {
            AddGameObject<ActorTitle>(1, Game.Camera.Size / 2 + Vector2Int.Up * 6);
            
            AddSpriteObject(1, Game.Camera.Size - SpriteDatabase.SprControls.Data.Size - Vector2Int.One, SpriteDatabase.SprControls);

            // Create rain particles
            for (int i = 0; i < 100; i++) { AddGameObject<ActorRainParticle>(0, Vector2Int.Zero); }
        }
    }
}