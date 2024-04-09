using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public int Scenenum;
    public string ScenePWD;
    public bool inspace;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inspace = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inspace = false;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.F)&&inspace)
        {
            PlayerManager.instance.scenePWD = ScenePWD;
            SceneManager.LoadScene(Scenenum);
        }
    }

}
