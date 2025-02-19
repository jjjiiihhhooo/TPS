using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T>
{
    public virtual void Change(T player) { }
    public virtual void Enter(T player){ }
    public virtual void Update(T player) { }
    public virtual void Exit(T player) { }
}
