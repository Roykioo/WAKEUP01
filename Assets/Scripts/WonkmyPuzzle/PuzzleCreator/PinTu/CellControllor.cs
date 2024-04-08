using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControllor : MonoBehaviour
{
    public float ZRot;
    Vector3 startPos;
    Vector3 endPos;

    bool inArea = false;
    bool isSelected = false;

    public bool IsSelected { get => isSelected; set => isSelected = value; }
    public bool InArea { get => inArea; set => inArea = value; }

    public event OnSelctedJigsawCell OnSelcted;
    public event OnUnSelctedJigsawCell OnUnSelcted;

    private void OnMouseOver()
    {
        InArea = true;
    }

    private void Start()
    {
        GameSystem.gameSystem.inputManager.e_onMyMouseDown += GameSystem_onMyMouseDown;
        GameSystem.gameSystem.inputManager.e_onMyMouseOver += GameSystem_onMyMouseOver;
        GameSystem.gameSystem.inputManager.e_onMyMouseUp += GameSystem_onMyMouseUp;
    }

    private void GameSystem_onMyMouseDown()
    {
        if (InArea == false) return;

        Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camPos.z = 0;
        startPos = camPos;

        if (IsSelected)
        {
            IsSelected = false;
        }
        else
        {
            IsSelected = true;
            OnSelcted?.Invoke();
            GetComponentInParent<JigsawManager>().curSelectedCell = gameObject;
        }
    }

    private void GameSystem_onMyMouseOver()
    {
        if (InArea == false) return;
        Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camPos.z = 0;
        endPos = camPos;
        if (endPos.sqrMagnitude - startPos.sqrMagnitude > 0.1f)
        {
            transform.position = camPos;
        }
    }

    private void GameSystem_onMyMouseUp()
    {
        if (InArea == false) return;
        InArea = false;
        OnUnSelcted?.Invoke();
    }
}
