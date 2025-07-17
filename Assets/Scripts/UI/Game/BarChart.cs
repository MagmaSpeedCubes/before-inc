using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;

public class BarChart : MonoBehaviour
{
    [SerializeField] private float barMin = 0f;
    [SerializeField] private float barMax = 100f;
    [SerializeField] private Image bar;
    [SerializeField] private string gameInfoVariableName;

    private float initialWidth;

    void Awake()
    {
        bar.rectTransform.anchorMin = new Vector2(0f, bar.rectTransform.anchorMin.y);
        bar.rectTransform.anchorMax = new Vector2(0f, bar.rectTransform.anchorMax.y);
        bar.rectTransform.pivot = new Vector2(0f, bar.rectTransform.pivot.y);
        bar.rectTransform.anchoredPosition = Vector2.zero;

        // Record the initial width of the bar
        initialWidth = bar.rectTransform.sizeDelta.x;
    }

    void Update()
    {
        Type type = typeof(GameInfo);
        FieldInfo field = type.GetField(gameInfoVariableName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        float value = 0f;
        if (field != null)
        {
            value = Convert.ToSingle(field.GetValue(null));
        }
        float normalized = Mathf.InverseLerp(barMin, barMax, value);

        // Set the width based on normalized value
        bar.rectTransform.sizeDelta = new Vector2(initialWidth * normalized, bar.rectTransform.sizeDelta.y);
    }
}