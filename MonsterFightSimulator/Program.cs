using System;
using System.Diagnostics;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Game.Actors;
using MonsterFightSimulator.Game;
using System.Collections.Generic;

namespace MonsterFightSimulator
{
    class Program
    {
        public static RenderSurface ApplicationSurface = new RenderSurface(new Vector2Int(100, 20));
        public static RenderSurface CurrentSurface = ApplicationSurface;
        public static LayerList LayerList = new LayerList();

        public static List<ConsoleKey> PressedKeys = new List<ConsoleKey>();

        static void Setup()
        {
            ActorTest actor = new ActorTest();

            ActorTextBox textbox = new ActorTextBox
            {
                Position = new Vector2Int(5, 5)
            };

            LayerList.Add(1, actor);
            LayerList.Add(0, textbox);
            LayerList.Add(1, new LayerSprite(SpriteDatabase.SprTest2, new Vector2Int(10, 10)));
        }

        static void Main(string[] args)
        {
            // Run Setup Code
            Setup();

            // Configure Console
            Console.CursorVisible = false;

            // Setup timer
            Stopwatch elapsedTime = Stopwatch.StartNew();
            double currentTime = elapsedTime.Elapsed.TotalSeconds;

            // Game loop
            bool quit = false;
            while (!quit)
            {
                // Calculate deltatime
                double newTime = elapsedTime.Elapsed.TotalSeconds;
                float deltaTime = (float)(newTime - currentTime);
                currentTime = newTime;


                // Input
                PressedKeys.Clear();
                while (Console.KeyAvailable)
                {
                    PressedKeys.Add(Console.ReadKey(true).Key);
                }

                // Updating
                LayerList.Update(deltaTime);

                // Rendering
                Console.SetCursorPosition(0, 0);
                ApplicationSurface.Clear();
                LayerList.Render();

                // Draw application surface
                foreach (string line in ApplicationSurface.Texture) { Console.WriteLine(line); }
            }
        }
    }
}
