using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class UI 
{
    public static Dictionary<Type,UIBase> UIMap = new Dictionary<Type,UIBase>();
    public static void RegistUI(Type type, UIBase ui){
        if(!UIMap.ContainsKey(type)){
            UIMap.Add(type,ui);
        }
    }
    public static T GetUI<T>() where T:UIBase{
        Type type = typeof(T);
        if(UIMap.ContainsKey(type)){
            return UIMap[type] as T;
        }
        else{
            Debug.LogError($"找不到UI：{type.Name}");
            return null;
        }
    }
}
