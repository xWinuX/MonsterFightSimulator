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

            RenderSurface applicationSurface = new RenderSurface(new Vector2<int>(100, 100));

            char[][,] sprite = new char[2][,];

            sprite[0] = new char[2, 2]  {   {'h', 'h'}, 
                                            {'h', 'h'} };

            sprite[1] = new char[2, 2]  {   {'H', 'H'},
                                            {'H', 'H'} };


            Sprite test = new Sprite(sprite, 0.125f);


            double currentTime = elapsedTime.Elapsed.TotalMilliseconds;
            bool quit = false;

            Console.CursorVisible = false;

            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                // Calculate deltatime
                double newTime = elapsedTime.Elapsed.TotalMilliseconds;
                float deltaTime = Convert.ToSingle(newTime - currentTime);
                currentTime = newTime;

                // Update
                test.Update(deltaTime);
                for (var x = 0; x < test.FrameSize.X; x++)
                {
                    for (var y = 0; y < test.FrameSize.Y; y++)
                    {
                        Console.Write(test.FrameCurrent[x, y]);
                    }
                    Console.WriteLine(" ");
                }


                // Render
                
            }
        }
    }
}
