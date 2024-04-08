using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogeManager : MonoBehaviour
{
    public static DialogeManager instance; 
    public GameObject DialogeBox;
    public TMP_Text dialogeText;
    [TextArea(1, 3)]
    public string[] dialogeLines;
    public int currentLine;
    public bool isScrolling;
    public float textspeed;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(DialogeBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isScrolling==false)
                {
                    currentLine++;
                    if (currentLine < dialogeLines.Length) { StartCoroutine(ScrollingText()); }
                    else { DialogeBox.gameObject.SetActive(false); }
                }
            }
        }
       
    }
    public void ShowDialogue(string[]  newlines)
    {
        dialogeLines = newlines;
        currentLine = 0;
        StartCoroutine(ScrollingText());
        DialogeBox.gameObject.SetActive(true);
    }
    public IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogeText.text = "";
        foreach(char letter in dialogeLines[currentLine].ToCharArray())
        {
            dialogeText.text += letter;
            yield return new WaitForSeconds(textspeed);
        }
        isScrolling = false;
    }
}
