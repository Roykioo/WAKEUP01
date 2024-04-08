using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string entrancePWD;
    public GameObject player;
    public void Start()
    {
        if(PlayerManager.instance.scenePWD==entrancePWD)
        {
            player.transform.position=new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
            FadeInOut.instance.In();
        }
    }
}
