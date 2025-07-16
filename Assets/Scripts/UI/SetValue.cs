using System;
using System.Reflection;
using UnityEngine;

public class SetValue : MonoBehaviour
{
    [SerializeField] private string variableName;
    [SerializeField] private string value; // Use string for serialization

    public void SetGameInfoValue()
    {
        Type type = typeof(GameInfo);
        FieldInfo field = type.GetField(variableName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        if (field != null)
        {
            object convertedValue = Convert.ChangeType(value, field.FieldType);
            field.SetValue(null, convertedValue);
        }
        else
        {
            Debug.LogError($"Field '{variableName}' not found in GameInfo.");
        }
    }
}