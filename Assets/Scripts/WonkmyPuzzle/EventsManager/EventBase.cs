using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : ScriptableObject
{
    public virtual bool Invoke() { return false; }

    public virtual void OnEventFinished(bool state) { }
}
