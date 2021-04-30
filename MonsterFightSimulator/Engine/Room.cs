using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class Room
    {
        private bool _firstUpdate = true;
        
        private  LayerList _layerList    = new LayerList();

        public Game Game { get; set; }

        public virtual void Setup() { }

        public void Reset()
        {
            _layerList   = new LayerList();
            _firstUpdate = true;
        }
        
        public void DestroyObject(GameObject gameObject) { _layerList.Remove(gameObject); }

        public void AddGameObject(int depth, GameObject gameObject)
        {
            gameObject.Game = Game;
            
            if (_firstUpdate) {_layerList.AddDirectly(depth, gameObject);}
            else { _layerList.Add(depth, gameObject);}
        }

        public T AddGameObject<T>(int depth, Vector2Int position) where T : GameObject, new()
        {
            T gameObject = new T();
            gameObject.Transform.Position = position;
            AddGameObject(depth, gameObject);
            return gameObject;
        }

        public void AddSpriteObject(int depth, Vector2Int position, SpriteData spriteData)
        {
            SpriteObject spriteObject = new SpriteObject(position, spriteData) {Game = Game};
            AddGameObject(depth, spriteObject);
        }

        public void AddSpriteObject(int depth, Vector2Int position, Sprite sprite)
        {
            SpriteObject spriteObject = new SpriteObject(position, sprite) {Game = Game};
            AddGameObject(depth, spriteObject);
        }

        public void Render() { _layerList.Render(); }

        public void Update()
        {
            if (_firstUpdate)
            {
                _firstUpdate = false;
                _layerList.Start();
            }

            _layerList.Update();
        }

        public void RoomEnd() { _layerList.RoomEnd(); }
    }
}