using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WinCondition : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Image bg;


    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private AudioSource gameAudio;
    [SerializeField] private Canvas[] hide;
    void Update()
    {
        if (HasLost())
        {
            EndGame(false);
        }
        else if (HasWon())
        {
            EndGame(true);
        }
    }

    public bool HasLost()
    {
        return Timer.IsRunning() & ((GameInfo.environment <= 0 || GameInfo.support <= 0) ||(Timer.GetTime() > 900 && !HasWon()));
    }
    public bool HasWon()
    {
        if (!Timer.IsRunning())
        {
            return false;
        }
        switch (GameInfo.difficulty)
        {
            case "Base":
                return GameInfo.averageTemperatureChange < 5 && Timer.GetTime() > 900;
                break;
            case "Pro":
                return GameInfo.averageTemperatureChange < 4.5 && Timer.GetTime() > 900;
                break;
            case "Max":
                return GameInfo.averageTemperatureChange < 4 && Timer.GetTime() > 900;
                break;
            case "Ultra":
                return GameInfo.averageTemperatureChange < 3 && Timer.GetTime() > 900;
                break;

        }
        return false;
    }

    public void EndGame(bool win)
    {
        Timer.StopTimer();
        Timer.ResetTimer();
        canvas.enabled = true;

        for (int i = 0; i < hide.Length; i++)
        {
            hide[i].enabled = false;
        }
        if (win)
        {
            winText.text = "Victory";
            bg.color = new Color(0f, 0.4431373f, 0.008131095f, 1f);
        }
        else
        {
            winText.text = "Defeat";
            bg.color = new Color(0.4433962f, 0.1095052f, 0f, 1f);
        }
        menuAudio.Play();
        gameAudio.Stop();
    }



}
