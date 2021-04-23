using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Game.Actors;

namespace MonsterFightSimulator.Engine
{
    public abstract class GameObject
    {
        protected GameObject()
        {
            Id = _idCount;
            _idCount++;

            Name = "Actor" + Id.ToString();
        }

        public static T Instantiate<T>(int depth, Vector2Int position) where T : GameObject, new()
        {
            T gameObject = new T();
            gameObject.Transform.Position = position;
            Program.LayerList.Add(depth, gameObject);
            return gameObject;
        }
        
        public void Destroy(GameObject gameObject)
        {
            Program.LayerList.Remove(gameObject);
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public ObjectTransform Transform { get; } = new ObjectTransform();

        private static int _idCount;

        public virtual void Update(float deltaTime) {}

        public virtual void Render() {}
    }
}
