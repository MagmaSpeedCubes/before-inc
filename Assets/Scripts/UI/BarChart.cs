using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;

public class BarChart : MonoBehaviour
{
    [SerializeField] private float barMin = 0f;
    [SerializeField] private float barMax = 100f;
    [SerializeField] private Image bar;
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
        float normalized = Mathf.InverseLerp(barMin, barMax, value);
        bar.rectTransform.localScale = new Vector3(normalized, 1f, 1f);
    }
}