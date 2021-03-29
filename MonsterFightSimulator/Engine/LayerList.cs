using System.Collections.Generic;

namespace MonsterFightSimulator.Engine
{
    class LayerList
    {
        private SortedList<int, List<GameObject>> _list = new SortedList<int, List<GameObject>>();
        private SortedList<int, List<int>> _delete = new SortedList<int, List<int>>();


        public void Add(int depth, GameObject layerItem)
        {
            if (!_list.ContainsKey(depth)) { _list.Add(depth, new List<GameObject>()); }

            _list[depth].Add(layerItem);
        }        
        
        public void Remove(GameObject gameObject) 
        {
            foreach (KeyValuePair<int, List<GameObject>> layer in _list)
            {
                int index = layer.Value.FindIndex(x => x.ID == gameObject.ID);
                if (index != -1)
                {
                    if (!_delete.ContainsKey(layer.Key)) { _delete.Add(layer.Key, new List<int>()); }
                    _delete[layer.Key].Add(index);
                }
            }
        }

        public void Update(float deltaTime)
        {
            foreach (KeyValuePair<int, List<int>> layer in _delete)
            {
                foreach (int index in layer.Value) { _list[layer.Key].RemoveAt(index); }
            }

            _delete.Clear();

            foreach (KeyValuePair<int, List<GameObject>> layer in _list)
            {
                foreach(GameObject layerItem in layer.Value) { layerItem.Update(deltaTime); }
            }
        }
        
        public void Render()
        {
            foreach(KeyValuePair<int, List<GameObject>> layer in _list)
            {
                foreach(GameObject layerItem in layer.Value) { layerItem.Render(); }
            }
        }
    }
}
