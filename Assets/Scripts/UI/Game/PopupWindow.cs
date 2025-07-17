using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopupWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI bodyText;
    [SerializeField] private Image image;

    public static PopupWindow instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple popup windows detected. Destroying duplicate.");
            Destroy(this);
        }
    }

    public static void ShowPopupWindow(Sprite newImage, string title, string text)
    {
        instance.RenderPopupWindow(newImage, title, text);
    }
    public void RenderPopupWindow(Sprite newImage, string title, string text)
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.enabled = true;
        if (newImage != null)
        {
            image.sprite = newImage;
        }
        else
        {
            image.color = new Color(1f, 1f, 1f, 1f);
        }

        titleText.text = title;
        bodyText.text = text;
    }
}
