using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : UIBase
{
    //最大背包容量,如果是-1则代表无限容量
    const int maxNum = 20;
    public BpSlot[] slots = new BpSlot[maxNum];
    public GameObject content;
    protected override void OnStart()
    {
        for (int i = 0; i < maxNum; i++)
        {
            GameObject obj = GlobalMap.Ins.slotPrefab.OPGet();
            slots[i] = (obj.GetComponent<BpSlot>());
            obj.transform.SetParent(this.content.transform);
        }
    }
    public override void RefreshView()
    {
        List<Item> items = Inventory.Ins.itemList;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].item = items[i];
            else
            {
                slots[i].item = null;
            }
        }
    }
    public override void Show()
    {
        base.Show();
        this.On(EC.E_RefreshItem, this.RefreshView);
    }
    public override void Hide()
    {
        base.Hide();
        this.Off(EC.E_RefreshItem, this.RefreshView);
    }
}
