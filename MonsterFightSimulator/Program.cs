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
        public static Renderer Renderer = new Renderer(new Vector2Int(50, 20), new Vector2Int(50, 20));

        public static Camera Camera = Renderer.Camera;

        public static LayerList LayerList = new LayerList();

        public static List<ConsoleKey> PressedKeys = new List<ConsoleKey>();

        public static float DeltaTime = 0f;

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
                DeltaTime = (float)(newTime - currentTime);
                currentTime = newTime;


                // Input
                PressedKeys.Clear();
                while (Console.KeyAvailable)
                {
                    PressedKeys.Add(Console.ReadKey(true).Key);
                }

                // Updating
                LayerList.Update(DeltaTime);

                Renderer.Prepare(); 

                // Draw everything onto the renderer
                LayerList.Render();

                // Actually display the rendered image
                Renderer.Display();
            }
        }
    }
}
