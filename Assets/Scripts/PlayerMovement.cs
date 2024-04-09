using UnityEngine;
///<summary>
///Íæ¼ÒÒÆ¶¯
///</summary>
public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Vector2 PresentPosition;
    public float maxPos;
    public float minPos;
    public Animator Ani;
    public void Start()
    {
        Ani=GetComponent<Animator>();
    }
    public void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) Ani.SetBool("iswalking",true);
        else Ani.SetBool("iswalking", false);
        if (Input.GetAxis("Horizontal") < 0) transform.localScale = new Vector3(1,1,1);
        else if(Input.GetAxis("Horizontal") > 0) transform.localScale = new Vector3(-1, 1, 1);
        transform.position += new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*speed,0,0);
        if (transform.position.x > maxPos) { transform.position = new Vector3
                (maxPos,transform.position.y,transform.position.z); }
        if (transform.position.x < minPos)
        {
            transform.position = new Vector3
                (minPos, transform.position.y, transform.position.z);
        }
    }
}
