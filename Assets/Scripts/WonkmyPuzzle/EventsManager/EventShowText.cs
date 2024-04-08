using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NodeCanvas.DialogueTrees;

[CreateAssetMenu(fileName ="NewEvent",menuName = "CreateEvent/Event/ShowText")]
public class EventShowText : EventBase
{
    //public DialogueTreeController dialogController;
    public override bool Invoke()
    {
        //dialogController.StartDialogue(OnEventFinished);
        return false;
    }
    public override void OnEventFinished(bool state)
    {
        ItemData itemData = new ItemData();
        itemData.itemName = "������";
        itemData.itemIcon = null;
        GameSystem.gameSystem.MyBagManager.AddItem(itemData);
    }
}
