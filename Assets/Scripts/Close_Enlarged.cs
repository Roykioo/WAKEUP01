using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Enlarged : MonoBehaviour
{
    public GameObject enlarged;
    public GameObject player;
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.tag == "enlarged")
            {
                player.GetComponent<PlayerMovement>().enabled=true;
                enlarged.SetActive(false);
            }

        }
    }
}
