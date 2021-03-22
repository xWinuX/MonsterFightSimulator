using MonsterFightSimulator.Engine;
using System;

namespace MonsterFightSimulator.Game.Actors
{
    class ActorTextBox : Actor
    {
        public string[] Text { get; set; } = new string[1] { "This is a testajsadkasjdlasdj"};

        private int _textCurrent = 0;
        private float _textSpeed = 5f;
        private float _textProgress = 0f;

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _textProgress = Math.Clamp( _textProgress + (_textSpeed * deltaTime), 0, Text[_textCurrent].Length-1);
        }
        public override void Render()
        {
            RenderStringAt( Position, new string[1] { Text[_textCurrent].Substring(0, Convert.ToInt32(Math.Floor(_textProgress))) } );
        }
    }
}
