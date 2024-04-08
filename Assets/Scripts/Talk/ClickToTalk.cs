using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToTalk : MonoBehaviour
{
    [TextArea(1,3)]
    public string[] lines;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.tag == "talk"&&DialogeManager.instance.DialogeBox.activeInHierarchy==false)
            {
                DialogeManager.instance.ShowDialogue(lines);
            }
        }
    }
}
