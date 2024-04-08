using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///�����������ƶ�
///����ƶ���Χ�޶�
///</summary>
public class CameraSystem : MonoBehaviour
{
    public Transform playerTarget;
    public float moveTime;
    public float minPosition;
    public float maxPosition;
    private void LateUpdate()
    {
        if (playerTarget != null)
        {
            if (playerTarget.position.x != transform.position.x)
            {
                float targetPos = playerTarget.position.x;
                targetPos= Mathf.Clamp(targetPos, minPosition, maxPosition);
                transform.position = Vector3.Lerp(transform.position,new Vector3( targetPos,transform.position.y,transform.position.z), moveTime * Time.deltaTime);
            }
        }
    }
}
