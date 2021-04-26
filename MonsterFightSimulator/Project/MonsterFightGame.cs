using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project
{
    public class MonsterFightGame : Game
    {
        public MonsterFightGame(Vector2Int gameSize) : base(gameSize) { }

        protected override void Setup()
        {
            ActorTest actor = GameObject.InitializeAtPosition<ActorTest>(new Vector2Int(10, 10));
            CurrentRoom.AddGameObject(1, actor);            
            ActorTextBox text = GameObject.InitializeAtPosition<ActorTextBox>(new Vector2Int(10, 10));
            CurrentRoom.AddGameObject(2, text);
            CurrentRoom.AddSpriteObject(3, new Vector2Int(20, 10), SpriteDatabase.SprTest2);
        }
    }
}