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

        public void AddGameObject<T>(int depth, Vector2Int position) where T : GameObject, new()
        {
            GameObject gameObject = new T();
            gameObject.Transform.Position = position;
            AddGameObject(depth, gameObject);
        }
        
        public void AddGameObject(int depth, GameObject gameObject)
        {
            gameObject.Game = Game;
            _layerList.Add(depth, gameObject);
        }           
        
        public void AddSpriteObject(int depth, Vector2Int position, SpriteData spriteData)
        {
            SpriteObject spriteObject = new SpriteObject(position, spriteData) {Game = Game};
            _layerList.Add(depth, spriteObject);
        }

        public void AddSpriteObject(int depth, Vector2Int position, Sprite sprite)
        {
            SpriteObject spriteObject = new SpriteObject(position, sprite) {Game = Game};
            _layerList.Add(depth, spriteObject);
        }

        public void Render() { _layerList.Render(); }

        public void Update()
        {
            if (_firstUpdate)
            {
                _layerList.Start();
                _firstUpdate = false;
            }

            _layerList.Update();
        }
    }
}