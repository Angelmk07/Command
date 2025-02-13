using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    public abstract void Invoke(Vector2 position);
    public abstract void Undo();
    public abstract void ChangeTarget(GameObject obj);

}
