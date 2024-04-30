using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Show_Enlarged : MonoBehaviour
{
    public GameObject enlarged;
    public float duration;
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
        if (Input.GetKeyDown(KeyCode.F) && inspace)
        {
           
        }
    }

}