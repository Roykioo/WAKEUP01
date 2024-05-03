using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DeploySlot : ItemContainer
{
    public Image bg;
    protected override void refreshView()
    {
        base.refreshView();
        ResetView();

    }
    bool isInDraging = false;
    public void OnDragBegin()
    {
        ItemOperator.Ins.StartItem(this);
        isInDraging = true;
        FindingTarget();
    }
    public void OnDragEnd()
    {
        ItemOperator.Ins.EndItem();
        isInDraging = false;
        this.ResetView();
    }
    public void OnDragUpdate()
    {
        ItemOperator.Ins.DragUpdate();

    }
    //此物品正在被移动的时候
    public void FindingTarget()
    {
        bg.color = Color.yellow;
    }
    public void ResetView()
    {
        Color color = new Color();
        if (ColorUtility.TryParseHtmlString("#006C18", out color))
            bg.color = color;

    }
}

