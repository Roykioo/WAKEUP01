using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIShowText : MonoBehaviour,IPointerDownHandler
{
    public Text human_text;
    public Text dialog_Content_text;

    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
    }

    public void SetDialogContent(string humanName, string content)
    {
        human_text.text = humanName;
        dialog_Content_text.text = content;
    }
}
