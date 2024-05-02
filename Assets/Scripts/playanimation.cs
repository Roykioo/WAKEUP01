using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playanimation : MonoBehaviour
{
    public Animator animator;
    public int newID;
    public GameObject obj;
    public bool once;
    public bool inspace = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inspace = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inspace = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inspace&&once)
        {
            animator.SetBool("WALK", true);
            obj.GetComponent<PressToTalk>().ID[0] = newID;
            once = false;
        }
        else
        {
            animator.SetBool("WALK", false);
        }
    }
}
