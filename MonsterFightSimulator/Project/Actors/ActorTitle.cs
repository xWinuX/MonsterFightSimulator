using System;
using System.Timers;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Project.Rooms;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorTitle : Actor
    {
        private readonly Timer   _timerContinue = new Timer {Interval = 1000f, AutoReset = false};
        private          Vector2 _originalPosition;
        private          bool    _showContinue;

        public override void Start()
        {
            Sprite                 =  SpriteDatabase.SprTitle;
            _originalPosition      =  Transform.Position;
            _timerContinue.Elapsed += OnTimerContinueElapsed;
            _timerContinue.Start();
        }

        public override void Update()
        {
            base.Update();

            Transform.Position = _originalPosition + Vector2.Up * MathF.Sin(Game.ElapsedTime * 0.005f);

            if (_showContinue && InputDown(ConsoleKey.Enter)) { Game.RoomGoto<RoomCharacterCreation>(); }
        }

        public override void Render()
        {
            base.Render();

            RenderStringAt(new Vector2Int(Game.Camera.Size.X / 2, Game.Camera.Size.Y - 1), StringToTexture("By Edwin Baumann"),
                OriginHelper.Preset.MiddleCenter);
            if (_showContinue)
            {
                RenderStringAt(_originalPosition + Vector2.Down * 10f, StringToTexture("Press Enter to continue..."),
                    OriginHelper.Preset.MiddleCenter);
            }
        }

        private void OnTimerContinueElapsed(object sender, ElapsedEventArgs e) { _showContinue = true; }
    }
}