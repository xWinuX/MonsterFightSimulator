using System.Collections.Generic;

namespace MonsterFightSimulator.Engine
{
    class LayerItemList
    {
        private SortedList<int, List<ILayerItem>> _list = new SortedList<int, List<ILayerItem>>();

        public void Add(int depth, ILayerItem layerItem)
        {
            if (!_list.ContainsKey(depth)) {_list.Add(depth, new List<ILayerItem>());}

            _list[depth].Add(layerItem);
        }

        public void Update(float deltaTime)
        {
            foreach(KeyValuePair<int, List<ILayerItem>> layer in _list)
            {
                foreach(ILayerItem layerItem in layer.Value)
                {
                    layerItem.Update(deltaTime);
                }
            }
        }        
        
        public void Render()
        {
            foreach(KeyValuePair<int, List<ILayerItem>> layer in _list)
            {
                foreach(ILayerItem layerItem in layer.Value)
                {
                    layerItem.Render();
                }
            }
        }
    }
}
