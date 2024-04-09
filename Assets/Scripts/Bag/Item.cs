using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;//名字
    public Sprite itemImage;//图像
    [TextArea(1,3)]
    public string itemInfo;//物品描述
    public bool used;//是否被使用
    public bool owned;//是否拥有
}  
