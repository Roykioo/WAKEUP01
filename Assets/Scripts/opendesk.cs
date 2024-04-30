using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendesk : MonoBehaviour
{
    public GameObject locked_obj;

    // Update is called once per frame
    void Update()
    {
        if(!locked_obj.activeInHierarchy)
        {
            this.GetComponent<BoxCollider2D>().enabled = true; 
        }
    }
}
