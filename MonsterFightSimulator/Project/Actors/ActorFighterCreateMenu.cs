using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Project.Rooms;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorFighterCreateMenu : Actor
    {
        private enum MenuState
        {
            RaceSelection,
            Naming,
            StatsSelection,
            ConfirmBattle
        }

        private MenuState _currentState = MenuState.RaceSelection;
        
        private ActorSelector _selector;

        private readonly List<MonsterPrototype> _fighters     = new List<MonsterPrototype>();
        
        private MonsterPrototype CurrentFighter => _fighters[_currentFighterIndex];
        private int _currentFighterIndex;

        public override void Start()
        {
            _fighters.Add(new MonsterPrototype());
            _fighters.Add(new MonsterPrototype());
            _selector       = Instantiate<ActorSelector>(1, Transform.Position + Vector2.Down);
            _selector.Limit = new Vector2Int(0, 3);
        }

        public override void RoomEnd() { MonsterFightGame.MonsterPrototypes = _fighters; }

        public override void Update()
        {
            base.Update();

            if (InputDown(ConsoleKey.Enter))
            {
                switch (_currentState)
                {
                    case MenuState.RaceSelection:
                        Game.ClearKeyString();
                        _selector.ResetPosition();
                        _selector.Enabled   = false;
                        CurrentFighter.Race = Race.List[_selector.Position.Y];
                        _currentState       = MenuState.Naming;
                        break;

                    case MenuState.Naming:
                        CurrentFighter.Name  = Game.KeyString;
                        _selector.Enabled    = true;
                        _selector.Limit      = new Vector2Int(0, 4);
                        CurrentFighter.Stats = new Stats(CurrentFighter.Race.RangeProfile);
                        _currentState        = MenuState.StatsSelection;
                        break;

                    case MenuState.StatsSelection:
                        _selector.ResetPosition();
                        if (_currentFighterIndex < _fighters.Count - 1)
                        {
                            _currentFighterIndex++;
                            _currentState = MenuState.RaceSelection;
                        }
                        else { Game.RoomGoto<RoomBattle>(); }
                        break;
                }
            }

            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    _selector.Transform.Position = Transform.Position + Vector2.Down * 2f + Vector2.Left * 4f;
                    break;

                case MenuState.StatsSelection:
                    _selector.Transform.Position =  Transform.Position + (Vector2.Down * 2f) + (Vector2.Left * 12f);
                    StatType statType = (StatType)_selector.Position.Y;
                    CurrentFighter.Stats[statType] += Convert.ToInt32(InputDown(ConsoleKey.D)) - Convert.ToInt32(InputDown(ConsoleKey.A));
                    CurrentFighter.Stats[statType] =  MyMathF.Clamp(CurrentFighter.Stats[statType], CurrentFighter.Race.RangeProfile[statType]);
                    break;
            }
        }


        public override void Render()
        {
            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    RenderStringAt(Transform.Position, StringToTexture("Select a Race for your Fighter:"), OriginHelper.Preset.MiddleCenter);
                    RenderStringAt(Transform.Position + Vector2.Down * 10f, new[]
                    {
                        "Health:  " + Race.List[_selector.Position.Y].RangeProfile.HealthRange,
                        "Attack:  " + Race.List[_selector.Position.Y].RangeProfile.AttackRange,
                        "Defense  " + Race.List[_selector.Position.Y].RangeProfile.DefenseRange,
                        "Speed:   " + Race.List[_selector.Position.Y].RangeProfile.SpeedRange,
                    }, OriginHelper.Preset.MiddleCenter);
                    RenderStringAt(Transform.Position + (Vector2.Down * 3f), Race.GetNamesFromExisting(), OriginHelper.Preset.MiddleCenter);
                    break;

                case MenuState.Naming:
                    RenderStringAt(Transform.Position, StringToTexture("Give your Fighter a Name ("+(Game.KeyStringLimit - Game.KeyString.Length)+"):"), OriginHelper.Preset.MiddleCenter);
                    RenderStringAt(Transform.Position + (Vector2.Down * 2f), StringToTexture(Game.KeyString), OriginHelper.Preset.MiddleCenter);
                    RenderStringAt(Transform.Position + (Vector2.Down * 3f), StringToTexture(new StringBuilder().Append('-', Game.KeyStringLimit).ToString()), OriginHelper.Preset.MiddleCenter);
                    break;

                case MenuState.StatsSelection:
                    // Text
                    RenderStringAt(Transform.Position, StringToTexture("Configure your Fighters Stats"), OriginHelper.Preset.MiddleCenter);
                    RenderStringAt(Transform.Position + Vector2.Down * 4f + Vector2.Left * 7f, new[]
                    {
                        "Health: ",
                        "Attack: ",
                        "Defense:",
                        "Speed:  ",
                    }, OriginHelper.Preset.MiddleCenter);          
                    
                    // Values
                    RenderStringAt(Transform.Position + Vector2.Down * 2f + Vector2.Right * 1f, new[]
                    {
                        CurrentFighter.Stats.Health.ToString(CultureInfo.InvariantCulture),
                        CurrentFighter.Stats.Attack.ToString(CultureInfo.InvariantCulture),
                        CurrentFighter.Stats.Defense.ToString(CultureInfo.InvariantCulture),
                        CurrentFighter.Stats.Speed.ToString(CultureInfo.InvariantCulture)   
                    }, OriginHelper.Preset.TopLeft);
                    
                    // Ranges
                    RenderStringAt(Transform.Position + Vector2.Down * 4f + Vector2.Right * 8f, new []
                    {
                        CurrentFighter.Race.RangeProfile.HealthRange.ToString(),
                        CurrentFighter.Race.RangeProfile.AttackRange.ToString(),
                        CurrentFighter.Race.RangeProfile.DefenseRange.ToString(),
                        CurrentFighter.Race.RangeProfile.SpeedRange.ToString()
                    }, OriginHelper.Preset.MiddleCenter);
                    break;
                
                case MenuState.ConfirmBattle:
                    RenderStringAt(Transform.Position, StringToTexture("Confirm battle?"), OriginHelper.Preset.MiddleCenter);
                    break;
            }
            
            DisplayFighterInfo();
        }

        private void DisplayFighterInfo()
        {
            List<string[]> infoStrings = new List<string[]>();
            foreach (MonsterPrototype fighter in _fighters)
            {
                List<string> fighterString = new List<string>();

                if (fighter.Race != null) { fighterString.Add("Race:     " + fighter.Race.Name); }
                if (fighter.Name != null) { fighterString.Add("Name:     " + fighter.Name); }
                if (fighter.Stats != null)
                {
                    fighterString.Add("Health:   " + fighter.Stats.Health.ToString(CultureInfo.InvariantCulture));
                    fighterString.Add("Attack:   " + fighter.Stats.Attack.ToString(CultureInfo.InvariantCulture));
                    fighterString.Add("Defense:  " + fighter.Stats.Defense.ToString(CultureInfo.InvariantCulture));
                    fighterString.Add("Speed:    " + fighter.Stats.Speed.ToString(CultureInfo.InvariantCulture));
                }

                infoStrings.Add(fighterString.ToArray());
            }

            if (infoStrings.Count == 2)
            {
                if (infoStrings[0].Length > 0) { RenderStringAt(new Vector2Int(5, 3), infoStrings[0], OriginHelper.Preset.TopLeft); }

                if (infoStrings[1].Length > 0) { RenderStringAt(new Vector2Int(Game.Camera.Size.X - 5, 3), infoStrings[1], OriginHelper.Preset.TopRight); }
            }
        }
    }
}