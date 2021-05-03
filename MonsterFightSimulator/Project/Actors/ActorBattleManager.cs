using System;
using System.Collections.Generic;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;
using MonsterFightSimulator.Project.Classes;

namespace MonsterFightSimulator.Project.Actors
{
    // strongly depends on MonsterFightGame.cs
    public class ActorBattleManager : Actor
    {
        private readonly List<ActorMonster> _monsterList = new List<ActorMonster>();
        private readonly List<int>          _roundQueue  = new List<int>();

        private bool _finished;
        private int  _round = 1;
        private int  _roundQueuePosition;

        private ActorTextBox _textBox;

        public override void Start()
        {
            foreach (MonsterPrototype monsterPrototype in MonsterFightGame.MonsterPrototypes)
            {
                ActorMonster actorMonster = new ActorMonster(monsterPrototype);
                _monsterList.Add(actorMonster);
                
                // Instantiate textbox
                Instantiate(0, new Vector2(10f, Game.Camera.Size.Y / 2f - 5f), actorMonster);
                _textBox = Instantiate<ActorTextBox>(1, Game.Camera.Size / 2 + Vector2Int.Down * 5);
            }
            
            // Check if the amount of monsters is 2 in case we want to battle more (if time to implement)
            if (_monsterList.Count == 2)
            {
                int index = 0;
                // If Monster have the same speed select a random one to start first
                if (_monsterList[0].Stats.Speed == _monsterList[1].Stats.Speed)
                {
                    index = Game.Random.Next(0, 2);
     
                    _textBox.AddNew("Both Monsters have the same speed!");
                    _textBox.AddNew("A random Monster will be chosen to attack first.");
                    _textBox.AddNew("The Monster will be " + _monsterList[index].Name);
                }
                else // Else evaluate which one is faster
                {
                    index = _monsterList[0].Stats.Speed > _monsterList[1].Stats.Speed ? 0 : 1;

                    _textBox.AddNew(_monsterList[index].Name + " is faster than " + _monsterList[index ^ 1].Name);
                    _textBox.AddNew(_monsterList[index].Name + " will attack first!");
                }

                // Add first monster to queue then the seconds one
                _roundQueue.Add(index);
                _roundQueue.Add(index^1); // 0 to 1 and 1 to 0 with XOR 

                // Update position of the second monster
                _monsterList[1].Transform.Position = new Vector2(Game.Camera.Size.X - 11f, Game.Camera.Size.Y / 2f - 5f);
            }
        }

        public override void Update()
        {
            // If current textbox is finished and user wants to advance calculate next turn
            if (_textBox.Finished && InputDown(ConsoleKey.Enter) && !_finished)
            {
                // Check if the amount of monsters is 2 in case we want to battle more (if time to implement)
                if (_monsterList.Count == 2)
                {
                    // Get index of the current monster
                    int index = _roundQueue[_roundQueuePosition];

                    // Evaluate current and target monster
                    ActorMonster currentMonster = _monsterList[index];
                    ActorMonster targetMonster  = _monsterList[index ^ 1];

                    // Attack the target monster and save dealt damage
                    float damageDone = currentMonster.Attack(targetMonster);
                
                    // Reset the textbox and display the dealt damage
                    _textBox.Reset();
                    _textBox.AddNew(currentMonster.Name + " dealt " + damageDone + " damage to " + targetMonster.Name);

                    // If the other monster is dead end the battle and return
                    if (targetMonster.Dead)
                    {
                        _textBox.Add(targetMonster.Name + " is dead!");
                        _textBox.Add(currentMonster.Name + " won the Fight!");
                        _textBox.Add("Battle lasted " + _round + " " + (_round == 1 ? "round" : "rounds"));
                        _finished = true;
                        return;
                    }
                    
                    // If the roundQueue is over increase the round counter and start a new one
                    if (_roundQueuePosition < _roundQueue.Count - 1) { _roundQueuePosition++;  }
                    else
                    {
                        _roundQueuePosition = 0;
                        _round++;
                    }
                } 
            }
        }

        public override void Render()
        {
            // Display rounds
            RenderStringAt(new Vector2Int(Game.Camera.Size.X/2, 1), StringToTexture("Round"), OriginHelper.Preset.MiddleCenter);
            RenderStringAt(new Vector2Int(Game.Camera.Size.X/2, 2), StringToTexture(_round.ToString()), OriginHelper.Preset.MiddleCenter);
        }
    }
}