using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject info;

    RectTransform content;

    public List<PuzzleItem> allItmes;

    [ProButton]
    public void InitAndAddItem()
    {
        //Init();
        //AddItem(new Item());
    }

    public void Init()
    {
        allItmes = new List<PuzzleItem>();
        content = scrollRect.content;
        info.SetActive(false);
    }

    public void ShowItemInfo(bool state)
    {
        info.SetActive(state);
    }
    public void AddItem(ItemData itemData)
    {
        GameObject newItemUI = Instantiate(Resources.Load<GameObject>("SimpleBagsystem/itemCell"));
        newItemUI.transform.SetParent(content);
        newItemUI.transform.localScale = Vector3.one;
        newItemUI.GetComponent<PuzzleItem>().Init(itemData);
        int childCount = content.childCount;
        float gap = content.GetComponent<VerticalLayoutGroup>().spacing;
        content.anchoredPosition = new Vector2(0, 0);
        content.sizeDelta = new Vector2(0, content.GetChild(0).GetComponent<RectTransform>().sizeDelta.y * childCount + (childCount - 1) * gap);
        allItmes.Add(newItemUI.GetComponent<PuzzleItem>());
        Debug.Log(string.Format("�����{0}", itemData.itemName));
    }
}
