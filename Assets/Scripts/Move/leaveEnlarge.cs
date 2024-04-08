using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class leaveEnlarge : MonoBehaviour
{
    public GameObject player;
    public void Update()
    {
        ClickToReturn();
    }
    public void ClickToReturn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null)
            {
               transform.parent.gameObject.SetActive(false);
               player.SetActive(true);
            }

        }
    }
}
