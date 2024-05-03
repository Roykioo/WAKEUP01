using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class judge : MonoBehaviour
{
    public GameObject[] objs;
    void Update()
    {
        foreach (GameObject obj in objs)
        {
            if (obj.activeInHierarchy)
            {
                return;
            }
        }
        this.GetComponent<SpriteRenderer>().enabled=true;
        this.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
