using MonsterFightSimulator.Core;
using MonsterFightSimulator.Rendering;

namespace MonsterFightSimulator.Engine
{
    public class Actor : ILayerItem, IHasPosition
    {
        public Vector2Int Position { get; set; } = new Vector2Int(0, 0);

        public virtual Sprite Sprite { get; set; } = null;

        public virtual void Start() {}

        public virtual void Update(float deltaTime) { if (Sprite != null) { Sprite.Update(deltaTime); } }

        public virtual void Render() { RenderSelf(); }

        protected void RenderSelf() { if (Sprite != null) { Program.CurrentSurface.RenderOn(Position, Sprite); } }
    }
}
