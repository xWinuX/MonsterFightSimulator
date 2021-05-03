using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorTextBox : Actor
    {
        public bool CurrentTextFinished => _textProgress == TextCurrentLength;
        public bool EnableBorder { get; set; } = false;

        public bool Finished => CurrentTextFinished && TextCurrent == Text.Count - 1;

        public bool AutoSize { get; set; } = true;

        public Vector2Int Size
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

        public List<List<string>> Text { get; } = new List<List<string>>();

        public int TextCurrent { get; private set; }

        private Vector2Int SizeMin
        {
            get
            {
             
                _sizeMin.X = Text[TextCurrent].OrderByDescending(line => line.Length).First().Length;
                _sizeMin.Y = 2 * Convert.ToInt32(EnableBorder) + Text[TextCurrent].Count;
                
                return _sizeMin;
            }
        }

        private int TextCurrentLength => Text[TextCurrent].Sum(line => line.Length);

        private Vector2Int _size    = Vector2Int.Zero;
        private Vector2Int _sizeMin = Vector2Int.Zero;

        private float _textProgress;

        private float _textSpeed = 20f;

        public void AddNew(string s) { Add(s, Math.Max(Text.Count, 1) - 1); }

        public void AddNew() { Text.Add(new List<string>()); }

        public void Add(string s, int index = 0)
        {
            while (Text.Count < index + 1) { Text.Add(new List<string>()); }

            Text[index].Add(s);
        }

        public override void Update()
        {
            if (Text.Count <= 0) { return; }

            if (_textProgress < TextCurrentLength) { _textProgress += _textSpeed * Game.DeltaTime; }
            else
            {
                _textProgress = TextCurrentLength;

                if (!InputDown(ConsoleKey.Enter)) { return; }

                AdvanceToNext();
            }
        }

        public override void Render()
        {
            if (Text.Count <= 0) { return; }

            if (AutoSize) { Size = Vector2Int.Zero; }

            string[] drawString  = new string[Size.Y];
            int      arrayOffset = Convert.ToInt32(EnableBorder);

            // Add text
            for (int i = arrayOffset, length = 0; i < Text[TextCurrent].Count + arrayOffset; i++)
            {
                // Cache text
                string text = Text[TextCurrent][i - arrayOffset];

                // Get progress
                int progress = Math.Clamp((int) Math.Floor(_textProgress) - length, 0, text.Length);

                // Add text and add side borders if enabled
                drawString[i] = text.Substring(0, progress);
                if (EnableBorder) { drawString[i] = "|" + drawString[i] + new StringBuilder().Append(' ', Size.X - progress) + "|"; }

                // Add length to calculate next progress
                length += text.Length;
            }

            // Fill rest of box with whitespace
            for (int i = Text[TextCurrent].Count + arrayOffset; i < Size.Y - arrayOffset; i++)
            {
                drawString[i] = "|" + new StringBuilder().Append(' ', Size.X) + "|";
            }

            // Add border if enabled
            if (EnableBorder)
            {
                string border = new StringBuilder().Append('=', Size.X + 2).ToString();
                drawString[0]          = border;
                drawString[Size.Y - 1] = border;
            }

            // Render TextBox
            for (int i = 0; i < drawString.Length; i++)
            {
                string line = drawString[i];
                RenderStringAt(Transform.Position + Vector2.Down * i, StringToTexture(line), OriginHelper.Preset.MiddleCenter);
            }
        }

        public void Reset()
        {
            Text.Clear();
            _textProgress = 0;
            TextCurrent   = 0;
        }

        private void AdvanceToNext()
        {
            if (TextCurrent >= Text.Count - 1) { return; }

            _textProgress = 0f;
            TextCurrent++;
        }
    }
}