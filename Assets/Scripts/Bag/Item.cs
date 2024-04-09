using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;//����
    public Sprite itemImage;//ͼ��
    [TextArea(1,3)]
    public string itemInfo;//��Ʒ����
    public bool used;//�Ƿ�ʹ��
    public bool owned;//�Ƿ�ӵ��
}  
