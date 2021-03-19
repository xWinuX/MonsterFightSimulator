using System;
using System.Diagnostics;
using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;
using MonsterFightSimulator.Engine;
using System.Collections.Generic;
using MonsterFightSimulator.Game.Actors;
using MonsterFightSimulator.Game;

namespace MonsterFightSimulator
{
    class Program
    {
        public static RenderSurface ApplicationSurface = new RenderSurface(new Vector2Int(100, 20));
        public static RenderSurface CurrentSurface = ApplicationSurface;

        static void Setup()
        {
            Console.CursorVisible = false;
        }

        static void Main(string[] args)
        {
            Setup();

            LayerItemList layerItemList = new LayerItemList();

            Stopwatch elapsedTime = Stopwatch.StartNew();
            double currentTime = elapsedTime.Elapsed.TotalSeconds;

            ActorTest actor = new ActorTest();

            LayerItemContainer layerItemContainer00 = new LayerItemContainer();
            layerItemContainer00.Add(actor);

            layerItemList.Add(0, actor);
            layerItemList.Add(1, new LayerSprite(SpriteDatabase.SprTest2, new Vector2Int(10,10)));

            // Game Loop
            bool quit = false;
            while (!quit)
            {
                // Calculate deltatime
                double newTime = elapsedTime.Elapsed.TotalSeconds;
                float deltaTime = Convert.ToSingle(newTime - currentTime);
                currentTime = newTime;

                // Reset Console Cursor
                Console.SetCursorPosition(0, 0);

                // Clear Application Surface
                ApplicationSurface.Clear();

                layerItemList.Update(deltaTime);

                layerItemList.Render();

                // Render Application Surface
                foreach (string line in ApplicationSurface.Texture)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
