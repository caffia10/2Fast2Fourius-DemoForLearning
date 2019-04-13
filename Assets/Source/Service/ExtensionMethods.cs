using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods 
{
    public static GameObject GetGameObjectByType<T>(this MonoBehaviour gameObject) where T : Behaviour
    {
        return FindObjectOfType<T>();
    }

    private static GameObject FindObjectOfType<T>() where T : Behaviour
    {
        return GameObject.FindObjectOfType<T>().gameObject;
    }

    public static T GetComponentFromUniqueInstance<T>(this MonoBehaviour gameObject) where T : Behaviour
    {
        GameObject gameObjectLocal = FindObjectOfType<T>();
        return gameObjectLocal.GetComponent<T>();
    }


}
