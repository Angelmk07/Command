using System.Collections.Generic;
using UnityEngine;
namespace CommandSystem 
{

    public class CreateObjCommand : Command
    {
        private GameObject _obj;
        private List<GameObject> _list;
        private int _maxRemember;
        public CreateObjCommand(GameObject obj, int maxRemember)
        {
            _obj = obj;
            _list = new List<GameObject>();
            _maxRemember = maxRemember;
        }

        public void ChangeTarget(GameObject obj)
        {
            _obj = obj;
        }

        public void Invoke(Vector2 position)
        {
            if (_list.Count >= _maxRemember)
            {
                _list.RemoveAt(0);
            }
            _list.Add(Object.Instantiate(_obj, position, Quaternion.identity));
        }

        public void Undo()
        {
            if (_list.Count > 0)
            {
                Object.Destroy(_list[_list.Count - 1]);
            }
        }
    }

}
