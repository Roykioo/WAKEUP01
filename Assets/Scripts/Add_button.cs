using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_button : MonoBehaviour
{
    public GameObject obj;
    public bool once = true;
    public Item item;
    void Start()
    {
        if(once)
        {
            obj.GetComponent<Inventory>().itemList.Add(item);
            once = false;
        }
    }

}
