using System;
using System.Timers;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorTitle : Actor
    {
        private Vector2 _originalPosition;
        private Timer   _timerContinue = new Timer() {Interval = 5000f, AutoReset = false};
        private bool    _showContinue  = false;

        public override void Start()
        {
            Sprite                 =  SpriteDatabase.SprTitle;
            _originalPosition      =  Transform.Position;
            _timerContinue.Elapsed += OnTimerContinueElapsed;
            _timerContinue.Start();
            
        }

        private void OnTimerContinueElapsed(object sender, ElapsedEventArgs e) { _showContinue = true; }

        public override void Update()
        {
            base.Update();

            Transform.Position = _originalPosition + Vector2.Up * (MathF.Sin(Game.ElapsedTime*0.005f));
        }

        public override void Render()
        {
            base.Render();

            if (_showContinue) { RenderStringAt(_originalPosition + Vector2.Down * 10f, StringToTexture("Press Space to continue...")); }
        }
    }
}