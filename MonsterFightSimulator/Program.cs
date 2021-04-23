using System;
using System.Diagnostics;
using System.Collections.Generic;

using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Game.Actors;
using MonsterFightSimulator.Game;

namespace MonsterFightSimulator
{
    internal static class Program
    {
        public static Renderer Renderer { get; private set; } = new Renderer(new Vector2Int(50, 20), new Vector2Int(50, 20));

        public static Camera Camera { get; private set; } = Renderer.Camera;

        public static LayerList LayerList { get; private set; } = new LayerList();

        public static List<ConsoleKey> PressedKeys { get; private set; } = new List<ConsoleKey>();

        public static bool Quit { get; set; } = false;

        public static float DeltaTime { get; private set; }

        private static void Setup()
        {
            ActorTest actor = new ActorTest();

            GameObject.Instantiate<ActorTextBox>(0, new Vector2Int(5, 5));

            LayerList.Add(1, actor);
            LayerList.Add(1, new LayerSprite(SpriteDatabase.SprTest2, new Vector2Int(10, 10)));
        }

        private static void Main(string[] args)
        {
            // Run Setup Code
            Setup();

            // Setup timer
            Stopwatch elapsedTime = Stopwatch.StartNew();
            double currentTime = elapsedTime.Elapsed.TotalSeconds;

            // Game loop
            while (!Quit)
            {
                // Calculate deltatime
                double newTime = elapsedTime.Elapsed.TotalSeconds;
                DeltaTime = (float)(newTime - currentTime);
                currentTime = newTime;

                // Input
                PressedKeys.Clear();
                while (Console.KeyAvailable) { PressedKeys.Add(Console.ReadKey(true).Key); }

                // Updating
                LayerList.Update(DeltaTime);

                // Draw everything onto the renderer
                Renderer.Prepare();
                LayerList.Render();

                // Actually display the rendered image
                Renderer.Display();
            }
        }
    }
}
