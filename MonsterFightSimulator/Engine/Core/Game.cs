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
        public Random Random { get; } = new Random();
        public float ElapsedTime => (float)_elapsedTime.Elapsed.TotalMilliseconds;
        
        public List<ConsoleKey> PressedKeys { get; } = new List<ConsoleKey>();
        public string KeyString = "";
        
        public void ClearKeyString() { KeyString = ""; }

        
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
            while (Console.KeyAvailable)
            {
                // Get Pressed Keys
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                PressedKeys.Add(keyInfo.Key);
                
                // Fill KeyString
                if (keyInfo.Key == ConsoleKey.Backspace) // Delete from KeyString if backspace was pressed
                {
                    // Check if string is empty
                    if (KeyString.Length > 0) { KeyString = KeyString.Remove(KeyString.Length - 1);}
                }
                else { KeyString += keyInfo.KeyChar; } // Just add the char to KeyString
            }
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