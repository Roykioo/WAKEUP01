using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class wardrobe : MonoBehaviour
{
    public bool isDragging = false;
    public GameObject moveObj=null;
    public Vector3 offset;
    public Vector3[] targetPos;
    public GameObject[] obj;
    public float snapDistance;
    public int presentTarget;
    void Update()
    { 
        if(JudgeObjPos())
        {
            Debug.Log("Win");
        }
        else
        {
            OnMouseDown();
            OnMouseDrag();
            OnMouseUp();
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null && hit.collider.tag == "wardrobe")
            {
                moveObj = hit.collider.gameObject;
                offset = moveObj.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isDragging = true;
            }
        }
    }
    private void OnMouseDrag()
    {
        if (isDragging && moveObj != null)
        {
            moveObj.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            SnapToTarget();
        }
    }
    public void SnapToTarget()
    {
        float minDistance = float.MaxValue;
        int nearestTarget = -1;
        for (int i = 0; i < targetPos.Length; i++)
        {
            float distance = Vector2.Distance(moveObj.transform.position, targetPos[i]);
            if (distance < snapDistance && distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = i;
            }
        }
        if(nearestTarget >= 0)
        {
            moveObj.transform.position = targetPos[nearestTarget];
        }

    }
    public bool JudgeObjPos()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].gameObject.transform.position != targetPos[i])
            {
                return false;
            }
        }
        return true;
    }
}
