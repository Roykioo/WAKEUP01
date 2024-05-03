using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : Singleton<Inventory>
{
    //最大背包容量,如果是-1则代表无限容量
    public int maxNum = 20;
    //玩家得到的物品列表（列表长度等于玩家得到的物品数量）
    public List<Item> itemList = new List<Item>();
    public bool isFull => itemList.Count >= maxNum;
    //通过id添加物品
    public bool AddItem(int id)
    {
        if (isFull)
            return false;
        else
        {
            AddItem(NewItem(id));
            return true;
        }
    }
    //通过item信息添加物品
    public bool AddItem(Item item)
    {
        if (isFull)
            return false;
        else
        {
            this.itemList.Add(item);
            return true;
        }
    }
    public bool RemoveItem(int id)
    {
        for (int i = 0; i < this.itemList.Count; i++)
        {
            if (itemList[i].id == id)
            {
                this.itemList.RemoveAt(i);
                return true;
            }
        }

        return false;
    }
    public bool RemoveItem(Item item)
    {
        if (itemList.Contains(item))
        {
            this.itemList.Remove(item);
            return true;
        }
        return false;
    }
    //根据物品id查找物品的配置
    public Item FindItemCfg(int id)
    {
        List<Item> list = GlobalMap.Ins.items;
        if (id < 0 || id >= list.Count)
            return null;
        return list[id];
    }
    //根据物品id创建一个新的item
    public Item NewItem(int id)
    {
        return FindItemCfg(id).Clone();
    }
}
