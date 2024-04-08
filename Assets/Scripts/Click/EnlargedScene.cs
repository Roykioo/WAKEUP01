using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnlargedScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null&&hit.collider.tag=="enlarged")
            {
                GameObject collided=hit.collider.gameObject;
                string aimobjname = collided.name;
                transform.parent.gameObject.transform.parent.gameObject.transform.Find(aimobjname).gameObject.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                DialogeManager.instance.DialogeBox.SetActive(false);
                FadeInOut.instance.In();
            }
            
        }
    }
}
