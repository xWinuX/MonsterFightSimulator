using System;
using System.Globalization;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorFighterCreateMenu : Actor
    {
        private enum MenuState
        {
            RaceSelection,
            Naming,
            StatsSelection
        }

        public ActorFighterCreateMenu()
        {
            _menuPoints     = Race.GetNamesFromExisting();
        }

        private ActorSelector _selector;
        
        private MenuState _currentState = MenuState.RaceSelection;
        private string[]  _menuPoints;

        private string       _fighterName;
        private Race         _fighterRace;
        private Stats _stats;

        public override void Start()
        {
            _selector       = Instantiate<ActorSelector>(1, Transform.Position + Vector2.Down);
            _selector.Limit = new Vector2Int(0, 3);
        }

        public override void Update()
        {
            base.Update();

            if (InputDown(ConsoleKey.Spacebar))
            {
                switch (_currentState)
                {
                    case MenuState.RaceSelection:
                        _fighterRace      = Race.List[_selector.Position.Y];
                        _currentState     = MenuState.Naming;
                        _selector.Enabled = false;
                        _selector.ResetPosition();
                        Game.ClearKeyString();
                        break;

                    case MenuState.Naming:
                        _fighterName      = Game.KeyString;
                        _currentState     = MenuState.StatsSelection;
                        //_stats     = new Stats();
                        _selector.Enabled = true;
                        break;

                    case MenuState.StatsSelection:
                        break;
                }
            }

            switch (_currentState)
            {
                case MenuState.Naming:
                    _menuPoints = new[] {Game.KeyString};
                    break;

                case MenuState.StatsSelection:
                    _menuPoints = new[]
                    {
                        _stats.Health.ToString(CultureInfo.InvariantCulture), 
                        _stats.Attack.ToString(CultureInfo.InvariantCulture), 
                        _stats.Defense.ToString(CultureInfo.InvariantCulture)
                    };
                    break;
            }
        }
        

        public override void Render()
        {
            // Display Message
            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    RenderStringAt(Transform.Position, StringToTexture("Select a Race for your Fighter:"));
                    RenderStringAt(Transform.Position + new Vector2(10f, 1f), new []
                    {
                        Race.List[_selector.Position.Y].RangeProfile.HealthRange.ToString(),
                        Race.List[_selector.Position.Y].RangeProfile.AttackRange.ToString(),
                        Race.List[_selector.Position.Y].RangeProfile.DefenseRange.ToString(),
                        Race.List[_selector.Position.Y].RangeProfile.SpeedRange.ToString(),
                    });
                    break;

                case MenuState.Naming:
                    RenderStringAt(Transform.Position, StringToTexture("Give your Fighter a Name:"));
                    break;

                case MenuState.StatsSelection:
                    RenderStringAt(Transform.Position, StringToTexture("Configure your Fighters Stats"));
                    break;
            }

            // Render List
            RenderStringAt(Transform.Position + Vector2.Down + Vector2.Right, _menuPoints);
        }
    }
}