using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputManager : IInput
{
    public event OnMyMouseDown e_onMyMouseDown;
    public event OnMyMouseOver e_onMyMouseOver;
    public event OnMyMouseUp e_onMyMouseUp;

    public void onMyMouseDown()
    {
        e_onMyMouseDown?.Invoke();
    }

    public void onMyMouseOver()
    {
        e_onMyMouseOver?.Invoke();
    }

    public void onMyMouseUp()
    {
        e_onMyMouseUp?.Invoke();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMyMouseDown();
        }
        if (Input.GetMouseButton(0))
        {
            onMyMouseOver();
        }
        if (Input.GetMouseButtonUp(0))
        {
            e_onMyMouseUp();
        }
    }
}
