using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleItem : MonoBehaviour,IPointerDownHandler
{
    public Image previewIcon;
    public Image frameImg;
    public ItemData itemData;
//Puzzle
    private bool pickup = false;

    public bool Pickup { get => pickup; set => pickup = value; }

    public void Init(ItemData _itemData)
    {
        itemData = _itemData;
        previewIcon.sprite = itemData.itemIcon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //1��������š����ߡ�����ʹ�øõ���
        //2�ٴε�������ȡ�������š����ߣ�����ʹ�øõ���
        if (Pickup)
        {
            Pickup = false;
            Debug.Log("������" + itemData + "����");
            frameImg.color = Color.red;
        }
        else
        {
            Pickup = true;
            Debug.Log("������" + itemData + "����");
            frameImg.color = Color.green;
        }
        SendMessageUpwards("ShowItemInfo", Pickup);
        //3������ߵ�ͬʱ����Ҫ��ʾһ�����Ե���ķŴ�ͼ�꣬������ʾ��ǰ���ߵ�ʹ��˵��
    }
}
