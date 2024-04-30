using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{
    public GameObject aim_obj;
    void Update()
    {
        if (!aim_obj.activeInHierarchy)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
