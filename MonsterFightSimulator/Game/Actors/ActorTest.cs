using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

using System;

namespace MonsterFightSimulator.Game.Actors
{
    class ActorTest : Actor
    {
        public override SpriteInstance SpriteInstance { get; set; } = new SpriteInstance(SpriteDatabase.SprTest);

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Vector2Int input = new Vector2Int(0, 0);

            // Input
            if (InputDown(ConsoleKey.D)) { input.X = 1; }
            if (InputDown(ConsoleKey.W)) { input.Y = -1; }
            if (InputDown(ConsoleKey.A)) { input.X = -1; }
            if (InputDown(ConsoleKey.S)) { input.Y = 1; }

            Position.Add(input);
            Program.Camera.Position.Add(input);
        }

        public override void Render()
        {
            base.Render();

            RenderSpriteAt(new Vector2Int(Position.X+10, Position.Y), SpriteDatabase.SprTest, SpriteInstance.FrameIndex);

            string[] str = new string[1] { Program.DeltaTime.ToString() };
            RenderStringAt(new Vector2Int(Position.X, Position.Y + 5), str);
        }
    }


}
