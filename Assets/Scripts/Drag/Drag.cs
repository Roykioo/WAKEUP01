using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private Transform correctTrans;
    [SerializeField] private bool isFinished;//Default false
    public EventCallBack OnUnlockedSuccessed;
    private void Start()
    {
        startPos = transform.position;
        collider2D = GetComponent<Collider2D>();
    }

    private void OnMouseDrag()
    {
        if (!isFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
           Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f)
        {
            transform.position = new Vector2(correctTrans.position.x, correctTrans.position.y);
            isFinished = true;
        }
        else
        {
            transform.position = new Vector2(startPos.x, startPos.y);
        }
    }

    private void OnMouseDown()
    {
        if (isFinished)
            return;
    }

    //MARKER Mobile Touch Control
    private Collider2D collider2D;
    private float offsetX, offsetY;

    private void Updte()
    {
        if (!isFinished && Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    //if(collider2D == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)))
                    //{
                    //    offsetX = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - transform.position.x;
                    //    offsetY = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y - transform.position.y;
                    //}
                    break;

                case TouchPhase.Moved:
                    if (collider2D == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)))
                    {
                        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x,
                                             Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
                    }
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(correctTrans.position.x, correctTrans.position.y);
                        isFinished = true;
                        OnUnlockedSuccessed.Invoke();
                        Debug.Log("drag");
                    }
                    else
                    {
                        transform.position = new Vector2(startPos.x, startPos.y);
                    }
                    break;
            }
        }
    }

}
