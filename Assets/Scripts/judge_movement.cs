using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judge_movement : MonoBehaviour
{
    public GameObject obj;
    public GameObject zhalan;
    public int aimID;
    public int aimPos;
    void Update()
    {
        if (obj.GetComponent<PressToTalk>().ID[0]==aimID)
        {
            this.GetComponent<PlayerMovement>().maxPos = aimPos;
            zhalan.gameObject.SetActive(false);
        }
    }
}
