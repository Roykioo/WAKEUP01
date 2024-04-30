using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_To_Change : MonoBehaviour
{
    public GameObject obj;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.tag == "change")
            {
                this.gameObject.SetActive(false);
                obj.SetActive(true);
            }
        }
    }
}
