using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class InteractiveManager : MonoBehaviour
{
    public Transform cameraPos;

    public InteractiveType interactiveType;

    Vector3 camOldPosition;
    private void Start()
    {
        camOldPosition = Camera.main.transform.position;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (interactiveType)
            {
                case InteractiveType.PUZZLE:
                    Camera.main.transform.DOMove(cameraPos.position - new Vector3(0, 0, 10), 0.8f);
                    Camera.main.DOOrthoSize(3.0f, 0.8f).OnComplete(() => {
                        GetComponent<BoxCollider>().enabled = false;
                    });
                    break;
                case InteractiveType.ITEM:
                    ItemData itemData = new ItemData();
                    itemData.itemName = "name";
                    itemData.itemIcon = GetComponentInChildren<SpriteRenderer>().sprite;
                    GameSystem.gameSystem.MyBagManager.AddItem(itemData);
                    Destroy(gameObject);
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            switch (interactiveType)
            {
                case InteractiveType.PUZZLE:
                    Camera.main.transform.DOMove(camOldPosition - new Vector3(0, 0, 10), 0.8f);
                    Camera.main.DOOrthoSize(8.0f, 0.8f).OnComplete(() => {
                        GetComponent<BoxCollider>().enabled = true;
                    });
                    break;
                case InteractiveType.ITEM:
                    break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);
    }
}
