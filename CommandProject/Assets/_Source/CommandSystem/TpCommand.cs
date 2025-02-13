using System.Collections.Generic;
using UnityEngine;
namespace CommandSystem
{
    public class TpCommand : Command
    {
        private GameObject _obj;
        private List<Vector2> _list = new List<Vector2>();
        private int _maxRemember;
        public TpCommand(GameObject obj, int maxRemember)
        {
            _obj = obj;
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
            _list.Add(_obj.transform.position);
            _obj.transform.position = position;
        }

        public void Undo()
        {
            if (_list.Count > 0)
            {
                _obj.transform.position = _list[_list.Count - 1];
            }

        }
    }

}
