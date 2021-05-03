using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Camera Camera { get; }

        public Room CurrentRoom { get; protected set; }
        public float DeltaTime { get; private set; }
        public float ElapsedTime => (float) _elapsedTime.Elapsed.TotalMilliseconds;
        public string KeyString { get; private set; } = "";
        public int KeyStringLimit { get; set; } = 10;

        public List<ConsoleKey> PressedKeys { get; } = new List<ConsoleKey>();

        public bool Quit { get; set; }

        public Random Random { get; } = new Random();
        public Renderer Renderer { get; }

        private readonly Stopwatch _elapsedTime;
        private          double    _currentTime;

        private Room _newRoom;

        public void ClearKeyString() { KeyString = ""; }

        public void RoomGoto<T>() where T : Room, new() { _newRoom = new T {Game = this}; } // This isn't optimal...

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

                // Skip enter
                if (keyInfo.Key == ConsoleKey.Enter) { continue; }

                // Fill KeyString
                if (keyInfo.Key == ConsoleKey.Backspace) // Delete from KeyString if backspace was pressed
                {
                    // Check if string is empty
                    if (KeyString.Length > 0) { KeyString = KeyString.Remove(KeyString.Length - 1); }
                }
                else if (KeyString.Length < KeyStringLimit)
                {
                    KeyString += keyInfo.KeyChar;
                } // Just add the char to KeyString if it isn't over the limit
            }
        }

        private void CheckForRoomChange()
        {
            if (_newRoom != null)
            {
                CurrentRoom?.RoomEnd();

                CurrentRoom = _newRoom;

                CurrentRoom.Setup();

                _newRoom = null;
            }
        }

        private void Update() { CurrentRoom.Update(); }

        private void Render()
        {
            Renderer.Prepare();

            CurrentRoom.Render();

            Renderer.Display();
        }
    }
}