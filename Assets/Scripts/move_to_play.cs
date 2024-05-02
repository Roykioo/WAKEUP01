using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class move_to_play : MonoBehaviour
{
    public GameObject player;
    public GameObject video;
    public int scenenum;
    public bool once=true;
    void Update()
    {
        if(player.GetComponent<Transform>().position.x>25)
        {
            if(once)
            {
                video.GetComponent<VideoPlayer>().Play();
                once = false;
            }
            else if (!video.GetComponent<VideoPlayer>().isPlaying)
            {
                SceneManager.LoadScene(scenenum);
            }
        }
    }
}
