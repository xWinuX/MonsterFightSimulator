using System;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorSelector : Actor
    {
        public ActorSelector() { Sprite = SpriteDatabase.SprSelector; }

        public bool Enabled { get; set; } = true;

        public Vector2Int Position { get => _position; private set => _position = value; }
        private Vector2Int _position = Vector2Int.Zero;

        public Vector2Int Limit
        {
            get => _limit;
            set => _limit = new Vector2Int(Math.Max(value.X, 1), Math.Max(value.Y, 1));
        }
        private Vector2Int _limit = Vector2Int.One;

        public void ResetPosition() => Position = Vector2Int.Zero;

        public override void Update()
        {
            base.Update();

            if (Enabled)
            {
                // Increase/Decrease with input
                _position += new Vector2Int(
                    Utility.BoolToInt32(InputDown(ConsoleKey.D)) - Utility.BoolToInt32(InputDown(ConsoleKey.A)),
                    Utility.BoolToInt32(InputDown(ConsoleKey.S)) - Utility.BoolToInt32(InputDown(ConsoleKey.W))
                );
            }

            // Wrap values between 0 and the amount of menu points
            _position = new Vector2Int(
                (int) MyMathF.Wrap(_position.X, 0, Limit.X),
                (int) MyMathF.Wrap(_position.Y, 0, Limit.Y)
            );
        }

        public override void Render()
        { 
            if (Enabled) {RenderSpriteAt(Transform.Position + (Vector2)_position, Sprite);}
        }
    }
}