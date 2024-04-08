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

    public void Update()
    {
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
