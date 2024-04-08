using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickCircle : MonoBehaviour
{
    Sequence sequence;
    public void Init()
    {
        transform.localScale = Vector3.zero;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    public void SetAnim()
    {
        Tween scale = transform.DOScale(0.36f, 0.5f);
        Tween fade = GetComponent<SpriteRenderer>().DOFade(1.0f, 0.5f).OnComplete(() => {
            Destroy(gameObject);
        });

        sequence.Append(scale);
        sequence.Append(fade);

        sequence.Play();

    }
}
