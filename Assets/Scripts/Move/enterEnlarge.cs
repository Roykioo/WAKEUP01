using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterEnlarge : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            player.SetActive(false);
        }
    }
}
