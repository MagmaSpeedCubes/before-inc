using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Reflection;

public class TextData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private string textPrefix;
    [SerializeField] private string textSuffix;
    [SerializeField] private string gameInfoVariableName; // Name of GameInfo variable

    void Update()
    {
        // Get value from GameInfo using reflection
        Type type = typeof(GameInfo);
        FieldInfo field = type.GetField(gameInfoVariableName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        float value = 0f;
        if (field != null)
        {
            value = Convert.ToSingle(field.GetValue(null));
        }
        textObject.text = textPrefix + value + textSuffix;
    }
}