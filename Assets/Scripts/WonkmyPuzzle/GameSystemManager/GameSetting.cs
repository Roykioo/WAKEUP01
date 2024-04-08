using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameSetting", menuName = "GameSetting")]
public class GameSetting : ScriptableObject
{
    public int gameWidthView;
    public int gameHeightView;
}
