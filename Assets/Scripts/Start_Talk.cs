using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Talk : MonoBehaviour
{
    public int ID;
    void Start()
    {
        DialogeManager.instance.ShowDialogue(ID);

    }

}
