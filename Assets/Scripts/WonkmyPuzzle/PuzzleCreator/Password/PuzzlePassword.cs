using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePassword : MonoBehaviour
{
    public Transform pwdBitParent;

    [Header("��ǰ�����λ��")]
    public int howManyPwdBit = 4;
    [Header("ÿ�������Ƶļ��")]
    public float gap = 1.2f;
    [Header("�����������ƫ��")]
    public float offset = 1.0f;
    [Header("������Ĵ���?")]
    public string resultData;
    [Header("������ͼƬ����·��")]
    public string path;
    [Space(10)]
    [Header("-------------------------------------------")]
    [Header("�����ȴ�ʱ��(Timer����жϽ���ʧ��)"),Tooltip("��Timer�����һ�δ�������¶������ͻ�ֱ���жϽ���ʧ��")]
    public float timer = 2.0f;
    [Header("�������򿪺�Ļص������Զ��壩")]
    public List<EventCallBack> OnUnlockedSuccessedList;

    float t = 0;
    /// <summary>
    /// ��ǰ�Ƿ����ڰ������ⰴť��?
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
                Debug.Log("�����ʧ����");
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
            Debug.Log("��ϲ������ɹ�");
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
        //    //ֻ���ڴﵽĳ������ʱ�Ž�����һ���Ž���id++
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
        //�����������ʧ���߼�������򵥵���ʾһ����ʾ�ı�
        GameObject newDialogUI = Instantiate(Resources.Load<GameObject>("PuzzlePassword/UIShowText"));
        newDialogUI.transform.SetParent(GameObject.Find("DialogCanvas").transform);
        newDialogUI.transform.localScale = Vector3.one;

        newDialogUI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        newDialogUI.GetComponent<UIShowText>().SetDialogContent("�԰�", "������񲻶�");
    }
}
