using System;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorTest : Actor
    {
        public ActorTest()
        {
            Sprite = SpriteDatabase.SprTest;
        }
        
        public override void Update()
        {
            base.Update();

            Vector2 input = Vector2.Zero;

            // Movement
            if (InputDown(ConsoleKey.D)) { input.X = 1; }
            if (InputDown(ConsoleKey.W)) { input.Y = -1; }
            if (InputDown(ConsoleKey.A)) { input.X = -1; }
            if (InputDown(ConsoleKey.S)) { input.Y = 1; }

            Transform.Position += input;

            // Quitting the game
            if (InputDown(ConsoleKey.Escape)) { GameQuit(); }

            Game.Camera.SetTarget(Transform.Position);
        }

        // public override void Render()
        // {
        //     base.Render();
        //
        //     //RenderSpriteAt(new Vector2Int(Position.X+10, Position.Y), SpriteDatabase.SprTest, SpriteInstance.FrameIndex);
        //     //
        //     //string[] str = new string[1] { Program.DeltaTime.ToString() };
        //     //RenderStringAt(new Vector2Int(Position.X, Position.Y + 5), str);
        // }   
    }
}
