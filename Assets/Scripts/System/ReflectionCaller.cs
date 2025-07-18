using System;
using System.Reflection;
using UnityEngine;

public class ReflectionCaller : MonoBehaviour
{

    public static ReflectionCaller instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple ReflectionCallers detected. Destroying duplicate.");
            Destroy(this);
        }
    }

    public static void CallFunctionRemote(string scriptName, string functionName)
    {
        instance.CallFunction(scriptName, functionName);
    }
    public void CallFunction(string scriptName, string functionName)
    {
        Type type = Type.GetType(scriptName);
        if (type == null)
        {
            Debug.LogError("Type not found: " + scriptName);
            return;
        }
        MethodInfo method = type.GetMethod(functionName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        if (method == null)
        {
            Debug.LogError("Method not found: " + functionName);
            return;
        }

        object instance = null;
        if (!method.IsStatic)
        {
            // Find the first active instance in the scene
            instance = GameObject.FindObjectOfType(type);
            if (instance == null)
            {
                Debug.LogError("Instance of " + scriptName + " not found in scene.");
                return;
            }
        }

        method.Invoke(instance, null);
    }
}