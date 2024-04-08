using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
public class ChangeBackground : MonoBehaviour
{
    public GameObject[] Background;
    public int PresentPos=0;
    public float offset;
    public float[] init;
    public float LerpDuration;
    void Update()
    {
        CheckPresent();
        ClickToChangeButton();
    }
    public void CheckPresent()
    {
        if (PresentPos==0)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (PresentPos == (Background.Length-1))
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
    public void ClickToChangeButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.name == "RightTriangle")
            {
                FadeInOut.instance.In();
                Background[PresentPos].SetActive(false);
                PresentPos++;
                if (PresentPos==Background.Length) { PresentPos = Background.Length-1; }
                Background[PresentPos].SetActive(true);
                StartCoroutine(LerpRight());
            }
            else if (hit.collider != null && hit.collider.name == "LeftTriangle")
            {
                FadeInOut.instance.In();
                Background[PresentPos].SetActive(false);
                PresentPos--;
                if (PresentPos < 0) { PresentPos = 0; }
                Background[PresentPos].SetActive(true);
                StartCoroutine(LerpLeft());
            }
        }
    }
    public IEnumerator LerpRight()
    {
        Vector3 startPos = new Vector3(offset, 0, 0);
        float time = 0;
        while (time < LerpDuration)
        {
            time += Time.deltaTime;
            Background[PresentPos].transform.position = Vector3.Lerp(startPos, new Vector3(init[PresentPos], 0, 0), time / LerpDuration);
            yield return null;
        }
        yield return null;
    }

    public IEnumerator LerpLeft()
    {
        Vector3 startPos = new Vector3(-offset, 0, 0);
        float time = 0;
        while (time < LerpDuration)
        {
            time += Time.deltaTime;
            Background[PresentPos].transform.position = Vector3.Lerp(startPos, new Vector3(init[PresentPos], 0, 0), time/ LerpDuration);
            yield return null;
        }
        yield return null;
    }

}
