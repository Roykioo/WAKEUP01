using UnityEngine;
[CreateAssetMenu(fileName = "NewEventCallback", menuName = "CreateEvent/EventCallback")]
public class EventCallBack : ScriptableObject
{
    public EventBase eventBase;
    public object obj;

    public void Invoke()
    {
        eventBase.Invoke();
    }
}
