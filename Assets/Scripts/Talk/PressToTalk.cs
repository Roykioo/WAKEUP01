using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressToTalk : MonoBehaviour
{
    public int[] ID;
    public int index=0;
    public bool inspace = false;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inspace = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inspace = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&& inspace)
        {
            if (ID[index] == -1) return;
            player.GetComponent<PlayerMovement>().enabled = false;
            DialogeManager.instance.ShowDialogue(ID[index]);
            player.GetComponent<PlayerMovement>().enabled = true;
            if (index < ID.Length - 1)
            {
                index++;
            }
            else
            {
                index = ID.Length - 1;
            }
        }
    }
}
