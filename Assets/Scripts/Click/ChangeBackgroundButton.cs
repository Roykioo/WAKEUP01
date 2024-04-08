using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeBackgroundButton : MonoBehaviour
{
    public GameObject[] Background;
    public GameObject Button;
    void Update()
    {
        for (int i = 0; i < Background.Length; i++)
        {
            if (Background[i].activeSelf)
            {
                Button.gameObject.SetActive(true);
                return;
            }
        }
        Button.gameObject.SetActive(false);
    }
}
