using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void ShowBP(){
        UI.GetUI<BackpackUI>().Show();
    }
    public void HideBP(){
        UI.GetUI<BackpackUI>().Hide();

    }
}
