using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_To_Change_Scene : MonoBehaviour
{
    public string Scenenum;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.name == Scenenum)
            {
                int num = (int)float.Parse(Scenenum);
                SceneManager.LoadScene(num);
                FadeInOut.instance.In();
            }
        }
    }
}
