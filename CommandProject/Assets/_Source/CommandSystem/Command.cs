using UnityEngine;
namespace CommandSystem
{
    public interface Command
    {
        public abstract void Invoke(Vector2 position);
        public abstract void Undo();
        public virtual void ChangeTarget(GameObject obj) { }

    }
}

