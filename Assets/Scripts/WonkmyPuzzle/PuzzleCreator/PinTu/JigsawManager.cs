using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawManager : MonoBehaviour
{
    public int CellCounts;
    public Transform cellParent;

    public GameObject curSelectedCell { get; set; }

    [ProButton]
    public void CreateAllCell()
    {
        for (int i = 0; i < CellCounts; i++)
        {
            GameObject newCell = new GameObject(i.ToString(),typeof(SpriteRenderer),typeof(CellControllor), typeof(CircleCollider2D));
            newCell.transform.SetParent(cellParent);
            newCell.transform.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && curSelectedCell!=null && curSelectedCell.GetComponent<CellControllor>().IsSelected)
        {
            curSelectedCell.transform.eulerAngles += new Vector3(0, 0, curSelectedCell.GetComponent<CellControllor>().ZRot);
        }
    }
}
