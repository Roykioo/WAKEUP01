using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Reflection;
using System.Xml;

public class DialogeManager : MonoBehaviour
{
    public static DialogeManager instance; 

    public GameObject DialogeBox;
    public TMP_Text NameText;
    public TMP_Text DialogeText;

    public SpriteRenderer Character;
    public TextAsset DialogeAsset;

    List<List<string>> dialogeLines=new List<List<string>>();
    public List<string> TextLines=new List<string>();
    public List<string> NameLines = new List<string>();
    public int currentLine=0;
    public bool isScrolling;
    public float textspeed;

    public List<Sprite> sprites=new List<Sprite>();
    public Dictionary<string,Sprite> characterDic = new Dictionary<string,Sprite>();

    public void Awake()
    {
        characterDic["Ҷ��"] = sprites[0];
        characterDic["����"] = sprites[1];
        characterDic["����"] = sprites[2];
        characterDic["�ϳ�"] = sprites[3];
        characterDic["��"] = sprites[4];
        characterDic["ͬѧ"] = sprites[5];
        characterDic["������"] = sprites[6];
        characterDic["����1"] = sprites[7];
        characterDic["����2"] = sprites[8];
        characterDic["����"] = sprites[9];
        ReadText(DialogeAsset);
        if (instance == null)
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
        if (DialogeBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isScrolling==false)
                {
                    currentLine++;
                    if (currentLine < TextLines.Count) 
                    {
                        UpdataImage(NameLines[currentLine]); 
                        StartCoroutine(ScrollingText());
                    }
                    else 
                    { 
                        DialogeBox.gameObject.SetActive(false); 
                        TextLines.Clear(); 
                        NameLines.Clear();
                        Character.sprite = null;
                        currentLine = 0; 
                    }
                }
            }
        }
       
    }
    public void ShowDialogue(int ID)
    {
        string Sign = dialogeLines[ID][0];
        if(Sign=="#")
        {
            itemDialoge(ID);
        }
        else if (Sign == "&")
        {
            CharacterDialoge(ID);
            
        }
        if(NameLines.Count!=0) { UpdataImage(NameLines[0]); }
        StartCoroutine(ScrollingText());
        DialogeBox.gameObject.SetActive(true);
    }
    public IEnumerator ScrollingText()
    {
        isScrolling = true;
        DialogeText.text = "";
        NameText.text = "";
        if (NameLines.Count!=0)
        {
            NameText.text = NameLines[currentLine];
        }
        foreach (char letter in TextLines[currentLine].ToCharArray())
        {
            DialogeText.text += letter;
            yield return new WaitForSeconds(textspeed);
        }
        isScrolling = false;
    }
    public void ReadText(TextAsset DialogeAsset)
    {
        List<string> rows = new List<string>(DialogeAsset.text.Split('\n')); 
        for(int i = 0; i < rows.Count; i++)
        {
            dialogeLines.Add(new List<string>(rows[i].Split(',')));
        }
    }
    public void itemDialoge(int ID)
    {
        int index = ID;  
        while (dialogeLines[index][4]!="-1")
        {
            TextLines.Add(dialogeLines[index][3]);
            index = int.Parse(dialogeLines[index][4]);
            if (index == -1) return;
        }
    }
    public void CharacterDialoge(int ID)
    {
        int index = ID;
        while (dialogeLines[index][4] != "-1")
        {
            TextLines.Add(dialogeLines[index][3]);
            NameLines.Add(dialogeLines[index][2]);
            index = int.Parse(dialogeLines[index][4]);
            if (index == -1) return;
        }
    }
    public void UpdataImage(string name)
    {
        if(characterDic.ContainsKey(name))
        {
            Character.sprite = characterDic[name];
        }
        else
        {
            Character.sprite = null;
        }
    }
}
