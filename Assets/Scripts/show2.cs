using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show2 : MonoBehaviour
{
    public GameObject[] aim_obj;
    void Update()
    {
        foreach (GameObject obj in aim_obj)
        {
            if (obj.activeInHierarchy)
            {
                return;
            }
        }
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
