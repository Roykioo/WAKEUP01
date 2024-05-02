using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_button : MonoBehaviour
{
    public GameObject obj;
    public Item item;
    void Start()
    {
        obj.GetComponent<Inventory>().itemList.Add(item);
    }

}
