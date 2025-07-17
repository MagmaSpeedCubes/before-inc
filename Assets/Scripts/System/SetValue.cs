using System;
using System.Reflection;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetValue : MonoBehaviour
{
    [SerializeField] private string variableName;
    [SerializeField] private string value; // Use string for serialization
    [SerializeField] public float ticks;

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

    public void AddGameInfoValueSoft()
    {
        float valueToFloat = float.Parse(value);
        StartCoroutine(AddValueOverTicks(variableName, valueToFloat, ticks));
    }

    private IEnumerator AddValueOverTicks(string variableName, float valueToAdd, float ticks)
    {
        Type type = typeof(GameInfo);
        FieldInfo field = type.GetField(variableName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        if (field == null)
        {
            Debug.LogError($"Field '{variableName}' not found in GameInfo.");
            yield break;
        }

        float startTick = Timer.GetTime();
        float endTick = startTick + ticks;
        float amountPerTick = valueToAdd / ticks;

        while (Timer.GetTime() < endTick)
        {
            // Get current value
            float currentValue = Convert.ToSingle(field.GetValue(null));
            // Add increment
            field.SetValue(null, currentValue + amountPerTick * Time.deltaTime);
            yield return null;
        }
    }
}