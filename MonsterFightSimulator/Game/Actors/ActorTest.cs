﻿using MonsterFightSimulator.Core;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Rendering;
using System;

namespace MonsterFightSimulator.Game.Actors
{
    class ActorTest : Actor
    {
        public override Sprite Sprite { get; set; } = new Sprite(SpriteDatabase.SprTest);

        public override void Update(float deltaTime)
        {
            Vector2Int input = new Vector2Int(0, 0);
            // Input
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D:
                        input.X = 1;
                        break;
                    case ConsoleKey.W:
                        input.Y = -1;
                        break;
                    case ConsoleKey.A:
                        input.X = -1;
                        break;
                    case ConsoleKey.S:
                        input.Y = 1;
                        break;
                }
            }

            Position.Add(input);
        }
    }
}
