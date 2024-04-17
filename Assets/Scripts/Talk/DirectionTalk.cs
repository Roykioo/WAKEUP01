using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTalk : MonoBehaviour
{
    public int[] ID;
    public int index = 0;
    public GameObject player;
    public void Update()
    {
        if(SceneController.instance.firsttalk)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            DialogeManager.instance.ShowDialogue(ID[index]);
            player.GetComponent<PlayerMovement>().enabled = true;
            SceneController.instance.firsttalk = false;
        }
    }
}
