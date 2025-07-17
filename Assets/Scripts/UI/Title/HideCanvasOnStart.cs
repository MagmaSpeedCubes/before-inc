using UnityEngine;
using UnityEngine.UI;
public class HideCanvasOnStart : MonoBehaviour
{
    void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
