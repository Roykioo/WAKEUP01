using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    [Header("初始是否开启")]
    public bool activeOrigin  = false;
    private void Awake() {
        UI.RegistUI(this.GetType(),this);
    }
private void Start() {
        this.OnStart();
        if(activeOrigin)
        Show();
        else
        Hide();
}
protected virtual void OnStart(){

}
    public virtual void Show(){
        this.gameObject.SetActive(true);
        this.RefreshView();
    }
    public virtual void Hide(){
        this.gameObject.SetActive(false);
    }
    public virtual void RefreshView(){

    }
}