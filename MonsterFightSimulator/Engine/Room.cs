using MonsterFightSimulator.Engine.Core;
using MonsterFightSimulator.Engine.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class Room
    {
        public Room(Game game) { _game = game; }

        private readonly LayerList _layerList = new LayerList();

        private readonly Game _game;
        
        public void DestroyObject(GameObject gameObject) { _layerList.Remove(gameObject); }

        public void AddGameObject(int depth, GameObject gameObject)
        {
            gameObject.Game = _game;
            _layerList.Add(depth, gameObject);
        }
        
        public void AddSpriteObject(int depth, Vector2Int position, SpriteData spriteData)
        {
            SpriteObject spriteObject = new SpriteObject(position, spriteData) {Game = _game};
            _layerList.Add(depth, spriteObject);
        }

        public void AddSpriteObject(int depth, Vector2Int position, Sprite sprite)
        {
            SpriteObject spriteObject = new SpriteObject(position, sprite) {Game = _game};
            _layerList.Add(depth, spriteObject);
        }

        public void Render() { _layerList.Render(); }

        public void Update() { _layerList.Update(); }
    }
}