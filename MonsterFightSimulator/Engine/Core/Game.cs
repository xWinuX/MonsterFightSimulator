using System;
using System.Diagnostics;
using System.Collections.Generic;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine.Core
{
    public abstract class Game
    {
        protected Game(Vector2Int gameSize)
        {
            Camera   = new Camera(gameSize);
            Renderer = new Renderer(Camera, gameSize);

            _elapsedTime = Stopwatch.StartNew();

            CurrentRoom = new Room(this);
        }
        
        public bool Quit { get; set; }
        public float DeltaTime { get; private set; }
        public Room CurrentRoom { get; private set; }

        public Camera Camera { get; }

        public Renderer Renderer { get; }
        
        public List<ConsoleKey> PressedKeys { get; } = new List<ConsoleKey>();
        
        private readonly Stopwatch _elapsedTime;
        private          double    _currentTime;

        private List<Room> _roomList = new List<Room>();
        
        public void Run()
        {
            Setup();
            
            while (!Quit)
            {
                CalculateDeltaTime();

                GetInput();

                Update();

                Render();
            }
        }

        protected virtual void Setup() { }

        private void CalculateDeltaTime()
        {
            double newTime = _elapsedTime.Elapsed.TotalSeconds;
            DeltaTime    = (float) (newTime - _currentTime);
            _currentTime = newTime;
        }

        private void GetInput()
        {
            PressedKeys.Clear();
            while (Console.KeyAvailable) { PressedKeys.Add(Console.ReadKey(true).Key); }
        }

        private void Update()
        {
            CurrentRoom.Update();
        }

        private void Render()
        {
            Renderer.Prepare();
            CurrentRoom.Render();
            Renderer.Display();
        }
    }
}