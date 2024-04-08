using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePassword : MonoBehaviour
{
    public Transform pwdBitParent;

    [Header("当前密码的位数")]
    public int howManyPwdBit = 4;
    [Header("每个密码牌的间隔")]
    public float gap = 1.2f;
    [Header("整体的密码牌偏移")]
    public float offset = 1.0f;
    [Header("此谜题的答案是?")]
    public string resultData;
    [Header("密码牌图片所在路径")]
    public string path;
    [Space(10)]
    [Header("-------------------------------------------")]
    [Header("按键等待时长(Timer秒后判断解锁失败)"),Tooltip("即Timer秒后玩家还未做出按下动作，就会直接判断解锁失败")]
    public float timer = 2.0f;
    [Header("密码锁打开后的回调（可自定义）")]
    public List<EventCallBack> OnUnlockedSuccessedList;

    float t = 0;
    /// <summary>
    /// 当前是否正在按下任意按钮槽?
    /// </summary>
    bool isPress = false;
    private void Start()
    {
        for (int i = 0; i < pwdBitParent.childCount; i++)
        {
            pwdBitParent.GetChild(i).GetComponent<PwdBit>().Init(path);
        }
    }
    [ProButton]
    public void CreatePwdBit()
    {
        for (int i = 0; i < howManyPwdBit; i++)
        {
            GameObject newPwdbit = Instantiate(Resources.Load<GameObject>("PuzzlePassword/PwdBit2D"));
            newPwdbit.transform.SetParent(pwdBitParent);
            float totalLength = howManyPwdBit * gap;
            newPwdbit.transform.localPosition = new Vector3((i - (totalLength / 2.0f)) * gap + offset, 0, 0);
            newPwdbit.GetComponent<PwdBit>().Init(path);
        }
    }
    [ProButton]
    public void ClearPwdBit()
    {
        for (int i = 0; i < pwdBitParent.childCount; i++)
        {
            DestroyImmediate(pwdBitParent.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        if (isPress)
        {
            t += Time.deltaTime;
            if (t >= timer)
            {
                isPress = false;
                Debug.Log("你解锁失败了");
                OnUnLockFail();
            }
        }
    }

    public void CheckFinished()
    {
        isPress = true;
        t = 0;
        string curResult = "";
        for (int i = 0; i < pwdBitParent.childCount; i++)
        {
            int targetResult = pwdBitParent.GetChild(i).GetComponent<PwdBit>().CurDataIndex;
            curResult += targetResult.ToString();
        }
        if(curResult.Equals(resultData))
        {
            Debug.Log("恭喜你解锁成功");
            OnFinshUnLock();
            transform.gameObject.SetActive(false);
        }
    }

    int id = 0;
    void OnFinshUnLock()
    {
        //if (id >= OnUnlockedSuccessedList.Count) return;
        //bool state = OnUnlockedSuccessedList[id].Invoke();
        //if (state == true)
        //{
        //    //只有在达到某个触发时才进行下一个才进行id++
        //    id++;
        //    OnFinshUnLock();
        //}
        if (OnUnlockedSuccessedList.Count > 0)
        {
            OnUnlockedSuccessedList[0].Invoke();
        }
    }

    void OnUnLockFail()
    {
        //可以自行添加失败逻辑，这里简单的显示一个提示文本
        GameObject newDialogUI = Instantiate(Resources.Load<GameObject>("PuzzlePassword/UIShowText"));
        newDialogUI.transform.SetParent(GameObject.Find("DialogCanvas").transform);
        newDialogUI.transform.localScale = Vector3.one;

        newDialogUI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        newDialogUI.GetComponent<UIShowText>().SetDialogContent("旁白", "密码好像不对");
    }
}
