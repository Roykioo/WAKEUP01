using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployUI : UIBase
{
    public GameObject content;
    //每页显示多少个
    const int numPerPage =7;

    public int curPage = 0;
    //public Text text;

    public int pages => Mathf.Max(1, Inventory.Ins.itemList.Count / numPerPage);
    public List<Item> items
    {
        get
        {
            List<Item> res = new List<Item>();
            int startIdx = numPerPage * curPage;
            for (int i = startIdx; i < numPerPage + startIdx; i++)
            {
                res.Add(i >= Inventory.Ins.itemList.Count ? null : Inventory.Ins.itemList[i]);
            }
            return res;
        }
    }

    public DeploySlot[] slots = new DeploySlot[numPerPage];
    protected override void OnStart()
    {
        for (int i = 0; i < numPerPage; i++)
        {
            GameObject obj = GlobalMap.Ins.deploySlotPrefab.OPGet();
            slots[i] = (obj.GetComponent<DeploySlot>());
            obj.transform.SetParent(this.content.transform);
        }
    }
    public void LeftPage()
    {
        curPage = (curPage - 1 + pages) % pages;
        this.RefreshView();
    }
    public void RightPage()
    {
        curPage = (curPage + 1) % pages;
        this.RefreshView();

    }
    public override void RefreshView()
    {
        //text.text = $"{curPage + 1}/{pages}页";
        curPage = Mathf.Clamp(curPage, 0, pages);
        List<Item> list = items;
        for (int i = 0; i < numPerPage; i++)
        {
            slots[i].item = list[i];
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
