using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class ItemObj : ItemContainer
{
    public SpriteRenderer bg => this.GetComponent<SpriteRenderer>();
    public int itemId = 0;
    private void Start()
    {
        this.item = Inventory.Ins.NewItem(itemId);
    }
    private void OnMouseEnter()
    {
        if (!ItemOperator.Ins.isInDraging)
            bg.color = Color.gray;
    }
    private void OnMouseExit()
    {

        bg.color = Color.white;
    }
    private void OnMouseDown()
    {
        if (Inventory.Ins.isFull)
        {
            Debug.Log("背包满了");
        }
        else
        {
            Inventory.Ins.AddItem(item);
            this.Send(EC.E_RefreshItem);
            this.Pickuped();
        }
    }
    //被拿走
    public void Pickuped()
    {
        this.gameObject.SetActive(false);
    }
}
