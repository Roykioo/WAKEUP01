using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public int Scenenum;
    public string ScenePWD;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            PlayerManager.instance.scenePWD= ScenePWD;
            SceneManager.LoadScene(Scenenum);
        }
    }

}
