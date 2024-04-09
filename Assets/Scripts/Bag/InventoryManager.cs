using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager Instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public TMP_Text itemInformation;
    public void Awake()
    {
        if (Instance!= null)
        {
            Destroy(this);
        }
        Instance = this;
    }
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(Instance.slotPrefab, Instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(Instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
    }
}
