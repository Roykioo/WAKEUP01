using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class judgeScene : MonoBehaviour
{
    public bool once=true;
    public GameObject obj1;
    public GameObject obj2;
    private void Update()
    {
        if(!obj1.activeInHierarchy&&once)
        {
            this.GetComponent<VideoPlayer>().Play();
            once= false;  
            
        }
        if(!once&&!this.GetComponent<VideoPlayer>().isPlaying)
        {
            obj2.gameObject.SetActive(true);
        }
    }
}
