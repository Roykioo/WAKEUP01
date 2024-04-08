using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwdBit : MonoBehaviour
{
    [Header("密码的数据")]
    public string pwdData;
    [Header("密码的数据")]
    public AudioClip clickAudio;
    private string path;

    int curDataIndex = 0;

    public int CurDataIndex { get => curDataIndex; set => curDataIndex = value; }

    public void Init(string _path)
    {
        path = _path;
        SetSprite(CurDataIndex);
        clickAudio = Resources.Load<AudioClip>("Audios/click");
    }
    private void OnMouseDown()
    {
        try
        {
            AudioSource.PlayClipAtPoint(clickAudio, transform.position);
        }
        catch
        {
        }
        CurDataIndex++;
        if (CurDataIndex >= pwdData.Length)
        {
            CurDataIndex = 0;
        }
        SetSprite(CurDataIndex);
        transform.parent.parent.SendMessage("CheckFinished");
    }
    void SetSprite(int index)
    {
        Texture2D texture2D = Resources.Load<Texture2D>(path + index);
        Sprite sp = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        GetComponent<SpriteRenderer>().sprite = sp;
    }
}
