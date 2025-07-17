using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameHandler : MonoBehaviour
{

    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private AudioSource gameAudio;
    [SerializeField] private Sprite startImage;


    private static GameHandler instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple game handlers detected. Destroying duplicate.");
            Destroy(this);
        }
    }
    public void StartGame()
    {

        Timer.ResetTimer();
        Timer.StartTimer();

        menuAudio.Stop();
        gameAudio.Play();
        PopupWindow.ShowPopupWindow(startImage, "Welcome to Before Inc.", "You are in charge of the world's government. To win, you must mitigate the effects of climate change and restore the environment");

    }

    public void ShowDifficultySpecificPopup()
    {
        switch (GameInfo.difficulty)
        {
            case "Base":
                break;
            case "Pro":
                break;
            case "Max":
                break;
            case "Ultra":
                break;
            
        }
    }
}
