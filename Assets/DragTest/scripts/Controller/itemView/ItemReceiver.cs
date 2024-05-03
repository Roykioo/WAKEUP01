using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : MonoBehaviour
{
    public int AimItemID;
    public SpriteRenderer sprite => this.GetComponent<SpriteRenderer>();
    private void OnMouseEnter()
    {
        ItemOperator.Ins.AddReceiver(this);
    }
    private void OnMouseExit()
    {
        ItemOperator.Ins.RemoveReceiver(this);

    }
    public void OnEnterTarget()
    {
        sprite.color = Color.grey;
    }
    public void OnExitTarget()
    {
        sprite.color = Color.white;

    }
    //判断是否能被指定物品交互
    public bool CanBeTarget(Item item)
    {
        if (item.id == AimItemID) return true;
        else return false;
    }
    public void OnBeTarget(Item item)
    {
        float maxScale = 1.5f;
        TM.SetTimer(this.Hash("Scale"), 1, e =>
        {
            float scale = Mathf.Lerp(1, maxScale, e);
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            float alpha = Mathf.Lerp(1, 0, e);
            transform.SetAlpha(alpha);
        }, (s) => gameObject.SetActive(false));
    }
}
