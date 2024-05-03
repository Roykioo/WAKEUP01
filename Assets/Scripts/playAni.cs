using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAni : MonoBehaviour
{
    public Animator animator;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("run_with_doll", 0, 0);
        
    }
    private void Update()
    {
        if (this.transform.position.x <= -14)
        {
            this.gameObject.SetActive(false);

        }
        if(this.transform.position.x>=-2.55)
        {
            obj.SetActive(true);
        }
    }
}
