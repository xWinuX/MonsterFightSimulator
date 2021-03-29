using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine
{
    public class GameObject
    {
        public GameObject()
        {
            ID = _idCount;
            _idCount++;

            Name = "Actor" + ID.ToString();
        }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public Vector2Int Position { get; set; } = new Vector2Int(0, 0);

        private static int _idCount = 0;

        public virtual void Update(float deltaTime) {}

        public virtual void Render() {}
    }
}
