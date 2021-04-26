using System;
using System.Linq;
using System.Text;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorTextBox : Actor
    {
        public string[][] Text { get; set; } = { new[] { "aaaaaaaa", "aaaaaa", "aaaaaaaa" }, new[] { "bbbbbbbbb", "bbbbbbbbb" }, new[] { "a", "b", "c", "d"} };

        public bool EnableBorder { get; set; } = true;

        private int   _textCurrent;
        private float _textProgress;
        private float _textSpeed = 15f;

        private int TextCurrentLength => Text[_textCurrent].Sum(line => line.Length);

        private Vector2Int SizeMin
        {
            get
            {
                _sizeMin.X = Text[_textCurrent].OrderByDescending(line => line.Length).First().Length;
                _sizeMin.Y = (2 * Convert.ToInt32(EnableBorder)) + Text[_textCurrent].Length;
                return _sizeMin;
            }
        }
        private Vector2Int _sizeMin = Vector2Int.Zero;

        private Vector2Int Size
        {
            get
            {
                if (_size.X < SizeMin.X) { _size.X = SizeMin.X; }                
                if (_size.Y < SizeMin.Y) { _size.Y = SizeMin.Y; }

                return _size;
            }

            set
            {
                if (value.X < SizeMin.X) { value.X = SizeMin.X; }
                if (value.Y < SizeMin.Y) { value.Y = SizeMin.Y; }

                _size = value;
            }
        }
        private Vector2Int _size = Vector2Int.Zero;


        private void AdvanceToNext()
        {
            _textProgress = 0f;
            _textCurrent++;
        }

        public override void Update()
        {
            if (_textProgress < TextCurrentLength) { _textProgress += _textSpeed * Game.DeltaTime; }
            else
            {
                _textProgress = TextCurrentLength;
                
                if (!InputDown(ConsoleKey.Spacebar)) { return; }

                if (_textCurrent < Text.Length-1) { AdvanceToNext(); }
                else { Destroy(this); }
            }
        }

        public override void Render()
        {
            string[] drawString = new string[Size.Y];
            int arrayOffset = Convert.ToInt32(EnableBorder);

            // Add text
            for (int i = arrayOffset, length = 0; i < Text[_textCurrent].Length + arrayOffset; i++)
            {
                // Cache text
                string text = Text[_textCurrent][i - arrayOffset];
                
                // Get progress
                int progress = Math.Clamp( (int)Math.Floor(_textProgress) - length, 0, text.Length);

                // Add text with side borders
                drawString[i] =     "|"
                                +   text.Substring(0, progress) + new StringBuilder().Append(' ', Size.X - progress)
                                +   "|";

                // Add length to calculate next progress
                length += text.Length;
            }

            // Fill rest of box with whitespace
            for (int i = Text[_textCurrent].Length + arrayOffset; i < Size.Y - arrayOffset; i++)
            {
                drawString[i] = "|" + new StringBuilder().Append(' ', Size.X) + "|";
            }
            
            // Add border if enabled
            if (EnableBorder)
            {
                string border = new StringBuilder().Append('=', Size.X + 2).ToString();
                drawString[0] = border;
                drawString[Size.Y - 1] = border;
            }

            // Render TextBox
            RenderStringAt(Transform.Position, drawString);
        }
    }
}
