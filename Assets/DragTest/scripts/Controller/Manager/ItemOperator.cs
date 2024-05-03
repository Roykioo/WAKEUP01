using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOperator : Singleton<ItemOperator>
{
    public PreviewSlot preview;
    public bool isInDraging => !!preview.item;
    public List<ItemReceiver> receivers = new List<ItemReceiver>();
    public ItemReceiver target
    {
        get
        {
            if (receivers.Count == 0)
                return null;
            else
                return receivers[receivers.Count - 1];
        }
    }
    public void StartItem(ItemContainer container)
    {
        preview.item = container.item;
        preview.gameObject.SetActive(true);
    }
    public void EndItem()
    {

        if (target)
        {
            target.OnBeTarget(preview.item);
            Inventory.Ins.RemoveItem(preview.item);
            EC.Send(EC.E_RefreshItem);
        }
        preview.item = null;
        preview.gameObject.SetActive(false);

    }
    public void AddReceiver(ItemReceiver receiver)
    {
        target?.OnExitTarget();
        if (isInDraging && receiver.CanBeTarget(preview.item))
        {
            this.receivers.Add(receiver);
            target?.OnEnterTarget();
        }

    }
    public void RemoveReceiver(ItemReceiver receiver)
    {
        target?.OnExitTarget();
        this.receivers.Remove(receiver);
        if (isInDraging && target && target.CanBeTarget(preview.item))
        {
            target?.OnEnterTarget();
        }
    }
    public void DragUpdate()
    {

        if (preview.gameObject.activeSelf)
        {
            Vector3 Pos =new Vector3(Input.mousePosition.x, Input.mousePosition.y,1);
            preview.transform.position = Camera.main.ScreenToWorldPoint(Pos)+new Vector3(-0.1f,0.1f,0);
        }
    }
}
