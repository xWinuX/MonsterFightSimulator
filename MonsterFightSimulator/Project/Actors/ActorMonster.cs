using System;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Project.Classes;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorMonster : Actor
    {
        public ActorMonster(MonsterPrototype monsterPrototype)
        {
            Name  = monsterPrototype.Name;
            Race  = monsterPrototype.Race;
            Stats = monsterPrototype.Stats;
        }

        public bool Dead { get; private set; }
        public string Name { get; }
        public Race Race { get; }
        public Stats Stats { get; }

        private ActorHealthBar _healthBar;

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
            CheckForDeath();
            return actualDamage;
        }

        public float Attack(ActorMonster monster) { return monster.TakeDamage(Stats.Attack); }

        public override void Start()
        {
            _healthBar = new ActorHealthBar(Stats.Health, Stats.HealthMax);
            Instantiate(0, Transform.Position + Vector2.Up * 10f, _healthBar);
        }

        public override void Update()
        {
            base.Update();

            UpdateHealthBar();
        }

        public override void Render() { RenderStringAt(Transform.Position, StringToTexture(Name), OriginHelper.Preset.MiddleCenter); }

        private void CheckForDeath()
        {
            if (Stats.Health <= 0) { Dead = true; }
        }

        private void UpdateHealthBar()
        {
            _healthBar.UpdateValues(Stats.Health);
            _healthBar.Transform.Position = Transform.Position + Vector2.Up * 6f;
        }

        private float CalculateDamage(float damage) { return Math.Max(damage - Stats.Defense, 1); }
    }
}