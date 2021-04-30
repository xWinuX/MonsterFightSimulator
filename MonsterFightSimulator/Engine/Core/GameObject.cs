using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine.Core
{
    public abstract class GameObject
    {
        protected GameObject()
        {
            Id = _idCount;
            _idCount++;
        }

        public int Id { get; }

        public Transform Transform { get; } = new Transform();

        public Game Game { get; set; }
        
        public Sprite Sprite{ get; set; }

        private static int _idCount;
        
        protected T Instantiate<T>(int depth, Vector2 position) where T : GameObject, new()
        {
            T gameObject = new T();
            Instantiate(depth, position, gameObject);
            return gameObject;
        }
        
        protected void Instantiate(int depth, Vector2 position, GameObject gameObject)
        {
            gameObject.Game               = Game;
            gameObject.Transform.Position = position;
            gameObject.Start();
            Game.CurrentRoom.AddGameObject(depth, gameObject);
        }

        protected void Destroy(GameObject gameObject) { Game.CurrentRoom.DestroyObject(gameObject); }

        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void RoomEnd() { }

        public virtual void Render() { }
    }
}