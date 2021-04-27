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

        public ActorFighterCreateMenu() { _menuPoints = Race.GetNamesFromExisting(); }

        private MenuState _currentState = MenuState.RaceSelection;
        private string[]  _menuPoints;
        private int       _selectorPosition = 0;

        private string       _fighterName;
        private Race         _fighterRace;
        private MonsterStats _monsterStats;

        public override void Update()
        {
            base.Update();

            if (InputDown(ConsoleKey.Spacebar))
            {
                switch (_currentState)
                {
                    case MenuState.RaceSelection:
                        _fighterRace      = Race.List[_selectorPosition];
                        _currentState     = MenuState.Naming;
                        _selectorPosition = 0;
                        Game.ClearKeyString();
                        break;

                    case MenuState.Naming:
                        _fighterName  = Game.KeyString;
                        _currentState = MenuState.StatsSelection;
                        _monsterStats = new MonsterStats();
                        break;

                    case MenuState.StatsSelection:
                        break;
                }
            }

            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    ControlSelector();
                    break;

                case MenuState.Naming:
                    _menuPoints = new[] {Game.KeyString};
                    break;

                case MenuState.StatsSelection:
                    _menuPoints = new[]
                    {
                        _monsterStats.Health.ToString(CultureInfo.InvariantCulture), 
                        _monsterStats.Attack.ToString(CultureInfo.InvariantCulture), 
                        _monsterStats.Defense.ToString(CultureInfo.InvariantCulture)
                    };
                    ControlSelector();
                    break;
            }
        }

        private void ControlSelector()
        {
            // Increase/Decrease with input
            _selectorPosition += Utility.BoolToInt32(InputDown(ConsoleKey.S)) - Utility.BoolToInt32(InputDown(ConsoleKey.W));

            // Wrap values between 0 and the amount of menu points
            _selectorPosition = (int)MyMathF.Wrap(_selectorPosition, 0, _menuPoints.Length);
        }

        private void RenderSelector()
        {
            RenderStringAt((Transform.Position + Vector2.Left) + (Vector2.Down + (Vector2.Down * _selectorPosition)), StringToTexture(">"));
        }

        public override void Render()
        {
            // Display Message
            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    RenderStringAt(Transform.Position, StringToTexture("Select a Race for your Fighter:"));
                    RenderSelector();
                    break;

                case MenuState.Naming:
                    RenderStringAt(Transform.Position, StringToTexture("Give your Fighter a Name:"));
                    break;

                case MenuState.StatsSelection:
                    RenderStringAt(Transform.Position, StringToTexture("Configure your Fighters Stats"));
                    RenderSelector();
                    break;
            }

            // Render List
            RenderStringAt(Transform.Position + Vector2.Down, _menuPoints);
        }
    }
}