using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_To_Active : MonoBehaviour
{
    public GameObject obj;
    public string name;
    public bool once=true;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null&&hit.collider.name == name&&once)
            {
               obj.gameObject.SetActive(true);
                once=false;
            }
        }
    }
}
