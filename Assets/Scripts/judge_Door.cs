using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class judge_Door : MonoBehaviour
{
    public int ID;
    public bool once;
    public GameObject player;
    public bool inspace = false;
    public GameObject obj;
    public int scenenum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inspace = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inspace = false;
    }
    void Update()
    {
        if (obj.GetComponent<Inventory>().itemList.Count == 0 && Input.GetKeyDown(KeyCode.F) && inspace)
        {
            if (once)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                DialogeManager.instance.ShowDialogue(ID);
                player.GetComponent<PlayerMovement>().enabled = true;
                once = false;
            }
            else
            {
                SceneManager.LoadScene(scenenum);
            }
        }
    }
}
