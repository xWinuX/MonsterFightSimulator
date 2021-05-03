using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Project.Classes;
using MonsterFightSimulator.Project.Rooms;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorFighterCreateMenu : Actor
    {
        private MonsterPrototype CurrentFighter => _fighters[_currentFighterIndex];
        private readonly List<MonsterPrototype> _fighters = new List<MonsterPrototype>();
        private readonly List<Race>             _races    = new List<Race>();
        private          int                    _currentFighterIndex;

        private MenuState _currentState = MenuState.RaceSelection;

        private ActorSelector _selector;

        public override void Start()
        {
            // Cache all available races
            foreach (Race race in Race.List) { _races.Add(race); }

            // Add to monster prototypes to available fighters
            _fighters.Add(new MonsterPrototype());
            _fighters.Add(new MonsterPrototype());
            
            // Create and configure selector
            _selector       = Instantiate<ActorSelector>(1, Transform.Position + Vector2.Down);
            _selector.Limit = new Vector2Int(0, _races.Count);
        }

        public override void RoomEnd() { MonsterFightGame.MonsterPrototypes = _fighters; }

        public override void Update()
        {
            base.Update();

            // Continue to next Menu
            if (InputDown(ConsoleKey.Enter))
            {
                switch (_currentState)
                {
                    case MenuState.RaceSelection:
                        // Select race for current fighter
                        CurrentFighter.Race = _races[_selector.Position.Y];
                        
                        // Remove selected race so it can't be selected again
                        _races.RemoveAt(_selector.Position.Y);

                        // Reconfigure Selector
                        _selector.ResetPosition();
                        _selector.Enabled   = false;

                        // Prepare for naming
                        Game.ClearKeyString();
                        
                        // Change to next menu
                        _currentState = MenuState.Naming;
                        break;

                    case MenuState.Naming:
                        if (Game.KeyString.Length == 0) { break; }

                        // Give name to fighter
                        CurrentFighter.Name  = Game.KeyString;
                        
                        // Reconfigure Selector
                        _selector.Enabled    = true;
                        _selector.Limit      = new Vector2Int(0, 4);
                        
                        // Prepare for StatsSelection
                        CurrentFighter.Stats = new Stats(CurrentFighter.Race.RangeProfile);
                        
                        // Change to next menu
                        _currentState        = MenuState.StatsSelection;
                        break;

                    case MenuState.StatsSelection:
                        // Update MaxHealth on the current fighter instance to lock in the health
                        CurrentFighter.Stats.UpdateHealthMax();
                        
                        // If there's more fighter to configure repeat 
                        if (_currentFighterIndex < _fighters.Count - 1)
                        {
                            // Reconfigure Selector
                            _selector.Limit = new Vector2Int(0, _races.Count);
                            _selector.ResetPosition();
                            
                            // Configure another fighter
                            _currentFighterIndex++;
                            _currentState = MenuState.RaceSelection;
                        }
                        else { Game.RoomGoto<RoomBattle>(); } // Else go to the battle room
                        break;
                }
            }

            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    // Position selector
                    _selector.Transform.Position = Transform.Position + Vector2.Down * 2f + Vector2.Left * 5f;
                    break;

                case MenuState.StatsSelection:
                    // Position selector
                    _selector.Transform.Position = Transform.Position + Vector2.Down * 2f + Vector2.Left * 13f;
                    
                    // Select and increase/decrease stats
                    StatType statType = (StatType) _selector.Position.Y;
                    CurrentFighter.Stats[statType] += Convert.ToInt32(InputDown(ConsoleKey.RightArrow)) - Convert.ToInt32(InputDown(ConsoleKey.LeftArrow));
                    CurrentFighter.Stats[statType] =  MyMathF.Clamp(CurrentFighter.Stats[statType], CurrentFighter.Race.RangeProfile[statType]);
                    break;
            }
        }


        public override void Render()
        {
            switch (_currentState)
            {
                case MenuState.RaceSelection:
                    // Display title 
                    RenderStringAt(Transform.Position, StringToTexture("Select a Race for your Fighter:"), OriginHelper.Preset.MiddleCenter);

                    // Display races
                    RenderStringAt(Transform.Position + Vector2.Down * 3f, _races.Select(x => x.Name).ToArray(), OriginHelper.Preset.MiddleCenter);
                    
                    // Display ranges
                    RenderStringAt(Transform.Position + Vector2.Down * 10f, new[]
                    {
                        "Health:  " + _races[_selector.Position.Y].RangeProfile.HealthRange,
                        "Attack:  " + _races[_selector.Position.Y].RangeProfile.AttackRange,
                        "Defense  " + _races[_selector.Position.Y].RangeProfile.DefenseRange,
                        "Speed:   " + _races[_selector.Position.Y].RangeProfile.SpeedRange
                    }, OriginHelper.Preset.MiddleCenter);
                    break;

                case MenuState.Naming:
                    // Display title and character limit
                    RenderStringAt(Transform.Position,
                        StringToTexture("Give your Fighter a Name (" + (Game.KeyStringLimit - Game.KeyString.Length) + "):"),
                        OriginHelper.Preset.MiddleCenter);
                    
                    // Display name
                    RenderStringAt(Transform.Position + Vector2.Down * 2f, StringToTexture(Game.KeyString), OriginHelper.Preset.MiddleCenter);
                    
                    // Display underline
                    RenderStringAt(Transform.Position + Vector2.Down * 3f,
                        StringToTexture(new StringBuilder().Append('-', Game.KeyStringLimit).ToString()), OriginHelper.Preset.MiddleCenter);
                    break;

                case MenuState.StatsSelection:
                    // Display title
                    RenderStringAt(Transform.Position, StringToTexture("Configure your Fighters Stats"), OriginHelper.Preset.MiddleCenter);
                    
                    // Display stat name
                    RenderStringAt(Transform.Position + Vector2.Down * 4f + Vector2.Left * 7f, new[]
                    {
                        "Health: ",
                        "Attack: ",
                        "Defense:",
                        "Speed:  "
                    }, OriginHelper.Preset.MiddleCenter);

                    // Display actual values
                    RenderStringAt(Transform.Position + Vector2.Down * 2f + Vector2.Right * 1f, new[]
                    {
                        CurrentFighter.Stats.Health.ToString(CultureInfo.InvariantCulture),
                        CurrentFighter.Stats.Attack.ToString(CultureInfo.InvariantCulture),
                        CurrentFighter.Stats.Defense.ToString(CultureInfo.InvariantCulture),
                        CurrentFighter.Stats.Speed.ToString(CultureInfo.InvariantCulture)
                    }, OriginHelper.Preset.TopLeft);

                    // Display Ranges
                    RenderStringAt(Transform.Position + Vector2.Down * 4f + Vector2.Right * 8f, new[]
                    {
                        CurrentFighter.Race.RangeProfile.HealthRange.ToString(),
                        CurrentFighter.Race.RangeProfile.AttackRange.ToString(),
                        CurrentFighter.Race.RangeProfile.DefenseRange.ToString(),
                        CurrentFighter.Race.RangeProfile.SpeedRange.ToString()
                    }, OriginHelper.Preset.MiddleCenter);
                    break;
            }

            DisplayFighterInfo();
        }

        private void DisplayFighterInfo()
        {
            // Continuously show more of the fighter as it gets configured
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

                if (infoStrings[1].Length > 0)
                {
                    RenderStringAt(new Vector2Int(Game.Camera.Size.X - 5, 3), infoStrings[1], OriginHelper.Preset.TopRight);
                }
            }
        }

        private enum MenuState
        {
            RaceSelection,
            Naming,
            StatsSelection,
        }
    }
}