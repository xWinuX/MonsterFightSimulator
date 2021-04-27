using System;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Project.Actors;

namespace MonsterFightSimulator.Project
{
    public class MonsterFightGame : Game
    {
        public MonsterFightGame(Vector2Int gameSize) : base(gameSize) { }

        public static Race Orc;
        public static Race Troll;
        public static Race Goblin;

        public static Random Random = new Random();

        protected override void Setup()
        {
            Orc    = new Race("Ork");
            Troll  = new Race("Troll");
            Goblin = new Race("Goblin");

            //CurrentRoom.AddSpriteObject(1, Camera.Size/2, SpriteDatabase.SprTitle);
            
            ActorTitle title = GameObject.InitializeAtPosition<ActorTitle>(Camera.Size/2);
            CurrentRoom.AddGameObject(5, title);
            
            //ActorFighterCreateMenu fighterCreateMenu = GameObject.InitializeAtPosition<ActorFighterCreateMenu>(new Vector2Int(2, 1));
            //CurrentRoom.AddGameObject(5, fighterCreateMenu);
        }
    }
}