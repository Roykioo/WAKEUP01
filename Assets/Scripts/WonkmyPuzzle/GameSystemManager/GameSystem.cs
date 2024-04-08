using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct MyVirabas
{
    public string vName;
    public bool vValue;
}
public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem;
    private GameSetting gameSetting;
    private BagManager bagManager;

    public List<MyVirabas> myVirabasList;
    public BagManager MyBagManager { get => bagManager; set => bagManager = value; }

    public MyInputManager inputManager;

    private void Awake()
    {
        gameSystem = this;
        Init();
    }

    void Init()
    {
        gameSetting = Resources.Load<GameSetting>("GameSetting");
        MyBagManager = FindObjectOfType<BagManager>();
        MyBagManager.Init();

        inputManager = new MyInputManager();
        inputManager.e_onMyMouseDown += GameSystem_onMyMouseDown;
    }

    private void GameSystem_onMyMouseDown()
    {
        Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camPos.z = 0;
        Utils.ShowClickCiecle(camPos);
    }

    private void Update()
    {
        inputManager.Update();
    }
    public int GetGameWidth()
    {
        return gameSetting.gameWidthView;
    }
    public int GetGameHeight()
    {
        return gameSetting.gameHeightView;
    }
}
