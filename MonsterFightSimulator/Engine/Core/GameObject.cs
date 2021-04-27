using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine.Core
{
    public abstract class GameObject
    {
        protected GameObject()
        {
            Id = _idCount;
            _idCount++;

            Name = "Actor" + Id.ToString();
        }

        public int Id { get; }

        public string Name { get; }

        public Transform Transform { get; } = new Transform();

        public Game Game { get; set; }
        
        public Sprite Sprite{ get; set; }

        private static int _idCount;

        public static T InitializeAtPosition<T>(Vector2 position) where T : GameObject, new()
        {
            T gameObject = new T();
            gameObject.Transform.Position = position;
            return gameObject;
        }

        protected T Instantiate<T>(int depth, Vector2 position) where T : GameObject, new()
        {
            T gameObject = new T();
            gameObject.Transform.Position = position;
            Game.CurrentRoom.AddGameObject(depth, gameObject);
            return gameObject;
        }

        protected void Destroy(GameObject gameObject) { Game.CurrentRoom.DestroyObject(gameObject); }

        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void Render() { }
    }
}