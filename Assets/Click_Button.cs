using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Click_Button : MonoBehaviour
{
    public GameObject Scene;
    public TMP_Text text;
    public void Click_Num()
    {
        if(text.text.Length<6) { text.text += this.name; }

    }
    public void Click_Num2()
    {
        if (text.text.Length <5) { text.text += this.name; }
    }
    public void Delete_Num()
    {
        if(text.text.Length>0) { text.text = text.text.Substring(0, text.text.Length-1);  }
    }
    public void Enter()
    {
        if(text.text== "061603") { Scene.gameObject.SetActive(false);}
    }
    public void Enter2()
    {
        if (text.text == "7770") { Scene.gameObject.SetActive(false); }
    }
}
