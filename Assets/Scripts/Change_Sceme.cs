using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Sceme : MonoBehaviour
{
    public GameObject[] objs;
    public string Scenenum;
    void Update()
    {
        foreach (GameObject obj in objs)
        {
            if (obj.activeInHierarchy) { return; }
        }
        int num = (int)float.Parse(Scenenum);
        SceneManager.LoadScene(num);
        FadeInOut.instance.In();
    }
}
