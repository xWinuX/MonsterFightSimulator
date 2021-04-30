using System;
using System.Globalization;
using System.Text;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorHealthBar : Actor
    {
        private const char BarFill = '#';
        
        private int _barLength;

        private float _health;
        private float _healthMax;
        
        public ActorHealthBar(float health, float healthMax)
        {
            Sprite     = SpriteDatabase.SprHealthBar;
            _barLength = Sprite.Data.Size.X-2;
            _health    = health;
            _healthMax = healthMax;
        }

        public void UpdateValues(float health) => UpdateValues(health, _healthMax);
        
        public void UpdateValues(float health, float healthMax)
        {
            _health    = health;
            _healthMax = healthMax;
        }

        public override void Render()
        {
            base.Render();

            int length = (int) MathF.Ceiling((_barLength / _healthMax) * _health);
            RenderStringAt(
                Transform.Position + Vector2.One - (Vector2) Sprite.Origin,
                StringToTexture(new StringBuilder().Append(BarFill, length).ToString()),
                OriginHelper.Preset.TopLeft
            );
            
            RenderStringAt(
                Transform.Position + (Vector2.Right * 2f) - (Vector2)Sprite.Origin, 
                StringToTexture(_health.ToString(CultureInfo.InvariantCulture))
            );
        }
    }
}