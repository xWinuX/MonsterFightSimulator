using System.Collections.Generic;
using System.Linq;

namespace MonsterFightSimulator.Engine.Core
{
    public class LayerList
    {
        private readonly SortedList<int, List<GameObject>> _add    = new SortedList<int, List<GameObject>>();
        private readonly SortedList<int, List<int>>        _delete = new SortedList<int, List<int>>();
        private readonly SortedList<int, List<GameObject>> _list   = new SortedList<int, List<GameObject>>();

        public void Add(int depth, GameObject gameObject)
        {
            if (!_add.ContainsKey(depth)) { _add.Add(depth, new List<GameObject>()); }

            _add[depth].Add(gameObject);
        }

        public void AddDirectly(int depth, GameObject gameObject)
        {
            if (!_list.ContainsKey(depth)) { _list.Add(depth, new List<GameObject>()); }

            _list[depth].Add(gameObject);
        }

        public void Remove(GameObject gameObject)
        {
            foreach ((int key, List<GameObject> value) in _list)
            {
                int index = value.FindIndex(x => x.Id == gameObject.Id);
                if (index == -1) { continue; }

                if (!_delete.ContainsKey(key)) { _delete.Add(key, new List<int>()); }

                _delete[key].Add(index);
            }
        }

        public void Start()
        {
            foreach (GameObject layerItem in _list.SelectMany(layer => layer.Value)) { layerItem.Start(); }
        }

        public void Update()
        {
            // Add all objects in the add queue
            foreach ((int key, List<GameObject> value) in _add)
            {
                foreach (GameObject gameObject in value)
                {
                    if (!_list.ContainsKey(key)) { _list.Add(key, new List<GameObject>()); }

                    _list[key].Add(gameObject);
                }
            }

            _add.Clear();

            // Delete all objects in delete queue
            foreach ((int key, List<int> value) in _delete)
            {
                foreach (int index in value) { _list[key].RemoveAt(index); }
            }

            _delete.Clear();


            // Update all objects
            foreach (GameObject layerItem in _list.SelectMany(layer => layer.Value)) { layerItem.Update(); }
        }

        public void Render()
        {
            foreach (GameObject layerItem in _list.SelectMany(layer => layer.Value)) { layerItem.Render(); }
        }

        public void RoomEnd()
        {
            foreach (GameObject layerItem in _list.SelectMany(layer => layer.Value)) { layerItem.RoomEnd(); }
        }
    }
}