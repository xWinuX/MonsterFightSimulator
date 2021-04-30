using System.Collections.Generic;
using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorBattleManager : Actor
    {
        private readonly List<ActorMonster> _monsterList = new List<ActorMonster>();

        public override void Start()
        {
            foreach (MonsterPrototype monsterPrototype in MonsterFightGame.MonsterPrototypes)
            {
                ActorMonster actorMonster = new ActorMonster(monsterPrototype);
                _monsterList.Add(actorMonster);
                Instantiate(0, new Vector2(10f, (Game.Camera.Size.Y/2f) - 3f), actorMonster);
            }

            if (_monsterList.Count == 2)
            {
                _monsterList[1].Transform.Position = new Vector2(Game.Camera.Size.X - 11f, (Game.Camera.Size.Y/2f) - 3f);
            }
        }
        
        public override void Update()
        {
            
        }


        public override void Render()
        {
            if (_monsterList.Count == 2)
            {

            }
        }
    }
}