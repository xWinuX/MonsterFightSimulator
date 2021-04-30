using System;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorMonster : Actor
    {
        public string Name { get; }

        public Race Race { get; }

        public Stats Stats { get; }
        
        private ActorHealthBar _healthBar;
        
        public ActorMonster(MonsterPrototype monsterPrototype)
        {
            Name  = monsterPrototype.Name;
            Race  = monsterPrototype.Race;
            Stats = monsterPrototype.Stats;
        }

        private float CalculateDamage(float damage) => Math.Max(damage /*- Stats.Defense*/, 0);

        public float ModifyHealth(float modify) { return modify < 0 ? TakeDamage(modify) : Heal(modify); }

        public float Heal(float heal)
        {
            float previousHealth = Stats.Health;
            Stats.Health = Math.Clamp(Stats.Health + MathF.Abs(heal), 0, Stats.HealthMax);
            return Stats.Health - previousHealth;
        }
        
        public float TakeDamage(float damage)
        {
            float actualDamage = CalculateDamage(MathF.Abs(damage));
            Stats.Health = Math.Max(Stats.Health - actualDamage, 0);
            return actualDamage;
        }
        
        public override void Start()
        {
            _healthBar = new ActorHealthBar(Stats.Health, Stats.HealthMax);
            Instantiate(0, Transform.Position + (Vector2.Up * 10f), _healthBar);
        }

        public override void Update()
        {
            base.Update();

            float ver = Convert.ToInt32(InputDown(ConsoleKey.D)) - Convert.ToInt32(InputDown(ConsoleKey.A));

            ModifyHealth(ver);
            
            _healthBar.UpdateValues(Stats.Health);
            _healthBar.Transform.Position = Transform.Position + (Vector2.Up * 10f);
        }

        public override void Render()
        {
            RenderStringAt(Transform.Position, StringToTexture(Name), OriginHelper.Preset.MiddleCenter);
        }
    }
}