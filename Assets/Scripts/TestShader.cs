using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShader : MonoBehaviour
{
    public float offsetY;

    Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        //transform.position = new Vector3(Mathf.Abs(Mathf.Cos(Time.deltaTime) * 2.0f), Mathf.Abs(Mathf.Sin(Time.deltaTime) * 2.0f), 0);
    }
}
