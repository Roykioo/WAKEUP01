using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    public Image image;
    public float alpha;
    public float speed;
    public void Start()
    {
        In();
    }
    public void In()
    {
        StartCoroutine("FadeIn");
    }
    public void Out()
    {
        StartCoroutine("FadeOut");
    }
    public void InAndOut()
    {
        StartCoroutine("InOut");
    }

    IEnumerator FadeOut()
    {
        alpha=0;
        while(alpha<=1)
        {
            alpha+=Time.deltaTime*speed;
            image.color=new Color(0,0,0,alpha);
            yield return null;
        }
        yield return null;
    }
    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha>=0)
        {
            alpha -= Time.deltaTime * speed;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }
    IEnumerator InOut()
    {
        alpha = 0;
        while (alpha <= 1)
        {
            alpha += Time.deltaTime * speed;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        while (alpha >= 0)
        {
            alpha -= Time.deltaTime * speed;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }
}
