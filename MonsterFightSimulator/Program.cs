using System;
using System.Diagnostics;
using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;


namespace MonsterFightSimulator
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch elapsedTime = new Stopwatch();
            elapsedTime.Start();

            RenderSurface applicationSurface = new RenderSurface(new Vector2Int(100, 20));

            string[][] sprite = new string[2][];

            sprite[0] = new string[3] { " @ " ,
                                        "/0\\",
                                        "/ \\"  };

            sprite[1] = new string[3] { " @ " ,
                                        "\\0/",
                                        " X"  };


            Sprite test = new Sprite(sprite, 0.125f);

            Console.Write(test.Texture);
            double currentTime = elapsedTime.Elapsed.TotalMilliseconds;
            bool quit = false;

            Console.CursorVisible = false;

            Vector2Int playerPosition = new Vector2Int(0, 0);
            Vector2Int input = new Vector2Int(0, 0);

            // Game Loop
            while (!quit)
            {
                // Reset Console Cursor
                Console.SetCursorPosition(0, 0);

                // Calculate deltatime
                double newTime = elapsedTime.Elapsed.TotalMilliseconds;
                float deltaTime = Convert.ToSingle(newTime - currentTime);
                currentTime = newTime;

                // Update
                test.Update(deltaTime);
                
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
                else
                {
                    input.X = 0;
                    input.Y = 0;
                }

                playerPosition.Add(input);
                
                // Render Application Surface
                foreach (string line in applicationSurface.Texture)
                {
                    Console.WriteLine(line);
                }

                // TESTING: (rendering sprites)
                applicationSurface.Clear();
                applicationSurface.RenderOn(new Vector2Int(0, 0), test);
                applicationSurface.RenderOn(playerPosition, test);



            }
        }
    }
}
