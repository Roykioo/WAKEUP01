using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    //物品的id，务必跟在GlobalMap中的引用对应，比如第0个物品的id就填0
    public int id;
    public string itemName;//����
    public Sprite itemImage;//ͼ��
    [TextArea(1,3)]
    public string itemInfo;//��Ʒ����
    public bool used;//�Ƿ�ʹ��
    public bool owned;//�Ƿ�ӵ��
    public  Item Clone(){
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.id = id;
        newItem.itemName = itemName;
        newItem.itemImage = itemImage;
        newItem.used = used;
        newItem.owned = owned;
        return newItem;
    }
}  
