using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCondition : MonoBehaviour
{
    private void Update()
    {
        if(SceneController.instance.checkdoor)
        {
            this.GetComponent<Exit>().enabled = true;
            this.GetComponent<PressToTalk>().enabled = false;
        }
    }
}
