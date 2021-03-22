using System;
using System.Diagnostics;
using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Game.Actors;
using MonsterFightSimulator.Game;

namespace MonsterFightSimulator
{
    class Program
    {
        public static RenderSurface ApplicationSurface = new RenderSurface(new Vector2Int(100, 20));
        public static RenderSurface CurrentSurface = ApplicationSurface;
        public static LayerItemList LayerItemList = new LayerItemList();

        static void Setup()
        {
            ActorTest actor = new ActorTest();

            ActorTextBox textbox = new ActorTextBox();
            textbox.Position = new Vector2Int(5, 5);

            LayerItemContainer layerItemContainer00 = new LayerItemContainer();
            layerItemContainer00.Add(actor);
            layerItemContainer00.Add(textbox);

            LayerItemList.Add(0, layerItemContainer00);
            LayerItemList.Add(1, new LayerSprite(SpriteDatabase.SprTest2, new Vector2Int(10, 10)));
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
                float deltaTime = Convert.ToSingle(newTime - currentTime);
                currentTime = newTime;

                // Updating
                LayerItemList.Update(deltaTime);

                // Rendering
                Console.SetCursorPosition(0, 0);
                ApplicationSurface.Clear();
                LayerItemList.Render();

                // Draw application surface
                foreach (string line in ApplicationSurface.Texture) { Console.WriteLine(line); }
            }
        }
    }
}
