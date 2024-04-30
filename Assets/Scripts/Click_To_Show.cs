using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_To_Show : MonoBehaviour
{
    public GameObject[] objs;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.tag == "bed")
            {
                foreach (var obj in objs)
                {
                    if (!obj.gameObject.activeInHierarchy)
                    {
                        obj.gameObject.SetActive(true);
                    }
                    else
                    {
                        obj.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
