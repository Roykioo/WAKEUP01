using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMap : Singleton<GlobalMap>
{
    public List<Item> items = new List<Item>();
    //资源列表，拖拽所有的scriptableObject，以便用id查找
    public GameObject slotPrefab;
    public GameObject deploySlotPrefab;
}
