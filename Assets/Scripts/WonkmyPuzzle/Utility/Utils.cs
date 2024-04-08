using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void ShowClickCiecle(Vector3 pos)
    {
        GameObject newCircle = Object.Instantiate(Resources.Load<GameObject>("clickCircle"));
        newCircle.transform.position = pos;
        newCircle.GetComponent<ClickCircle>().Init();
        newCircle.GetComponent<ClickCircle>().SetAnim();
    }
}
