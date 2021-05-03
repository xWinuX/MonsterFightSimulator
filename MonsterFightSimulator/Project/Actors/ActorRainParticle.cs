using MonsterFightSimulator.Engine;
using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorRainParticle : Actor
    {
        public ActorRainParticle() { Sprite = SpriteDatabase.SprRain; }

        private Vector2 _speed = Vector2.Zero;

        public override void Start() { Reset(); }

        public override void Update()
        {
            Transform.Position += _speed * Game.DeltaTime;

            if (Transform.Position.Y > Game.Camera.Size.Y) { Reset(); }
        }

        private void Reset()
        {
            Transform.Position = new Vector2(Game.Random.Next(0, Game.Camera.Size.X + 30), -Game.Random.Next(0, 50));
            _speed             = new Vector2(-Game.Random.Next(2, 5), Game.Random.Next(20, 30));
        }
    }
}