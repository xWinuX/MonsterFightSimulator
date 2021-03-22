using System.Collections.Generic;

namespace MonsterFightSimulator.Engine
{
    public class LayerItemContainer : ILayerItem
    {
        private List<ILayerItem> _layerItems = new List<ILayerItem>();
        
        public void Update(float deltaTime)
        {
            foreach(ILayerItem item in _layerItems) { item.Update(deltaTime); }
        }
        
        public void Render()
        {
            foreach(ILayerItem item in _layerItems) { item.Render(); }
        }

        public void Add(ILayerItem layerItem) { _layerItems.Add(layerItem); }
    }
}
