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
            
            RoomGoto<Room>();
            
            CheckForRoomChange();
        }

        public bool Quit { get; set; }
        public float DeltaTime { get; private set; }
        public float ElapsedTime => (float)_elapsedTime.Elapsed.TotalMilliseconds;
        public string KeyString { get; private set; } = "";

        public List<ConsoleKey> PressedKeys { get; } = new List<ConsoleKey>();

        public Random Random { get; } = new Random();

        public Room CurrentRoom { get; protected set; }
        public Camera Camera { get; }
        public Renderer Renderer { get; }
        
        
        private Room _newRoom;

        private readonly Stopwatch _elapsedTime;
        private          double    _currentTime;

        public void ClearKeyString() => KeyString = "";

        public void RoomGoto<T>() where T : Room, new() => _newRoom = new T {Game = this}; // This isn't optimal...

        public void Run()
        {
            Setup();
            
            while (!Quit)
            {
                CalculateDeltaTime();

                GetInput();
                
                Update();

                Render();

                CheckForRoomChange();
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

        private void CheckForRoomChange()
        {
            if (_newRoom != null)
            {
                CurrentRoom = _newRoom;

                CurrentRoom.Setup();

                _newRoom = null;
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