using UnityEngine;
using UnityEngine.UI;
public class MenuButton
{
    [SerializeField] private Canvas[] hideCanvas;
    [SerializeField] private Canvas showCanvas;

    public void OnClick()
    {
        for (int i = 0; i < hideCanvas.Length; i++)
        {
            hideCanvas[i].enabled = false;
        }
        showCanvas.enabled = true;
    }
}
