using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameHandler : MonoBehaviour
{

    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private AudioSource gameAudio;
    [SerializeField] private Sprite startImage;

    [SerializeField] private MapRegion[] mapRegions;


    private static GameHandler instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GameInfo.gameHandler = this;
        }
        else
        {
            Debug.LogWarning("Multiple game handlers detected. Destroying duplicate.");
            Destroy(this);
        }
    }
    public void StartGame()
    {

        GameInfo.gameSpeed = 0;
        GameInfo.environment = 100f;

        Timer.ResetTimer();
        Timer.StartTimer();

        for(int i=0; i<mapRegions.Length; i++) {
            mapRegions[i].Initialize();
        }
        

        menuAudio.Stop();
        gameAudio.Play();
        PopupWindow.ShowPopupWindow(startImage, "Welcome to Before Inc.", "You are in charge of the world's government. To win, you must mitigate the effects of climate change and restore the environment");

    }

    public void Tick()
    {
        GameInfo.populationInMillions = 0;
        GameInfo.globalWealth = 0;
        GameInfo.weightedTemperatureChange = 0;
        GameInfo.emissionRate = 0;
        GameInfo.weightedSupportLevel = 0;

        float oldTemperature = GameInfo.averageTemperatureChange;

        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].Tick();
            double warmingCoefficient = GameInfo.carbonInAtmosphere * 0.000000001;
            mapRegions[i].Warm((float)(warmingCoefficient));

        }


        GameInfo.globalWealth *= GameInfo.fundingCoefficient;

        GameInfo.currency += GameInfo.globalWealth;

        //Adds funding

        GameInfo.averageTemperatureChange = GameInfo.weightedTemperatureChange / GameInfo.populationInMillions;
        GameInfo.support = GameInfo.weightedSupportLevel / GameInfo.populationInMillions;
        GameInfo.carbonInAtmosphere += GameInfo.emissionRate / 12;
        GameInfo.recentTemperatureChange = 12 * (GameInfo.averageTemperatureChange - oldTemperature);

        float environmentalConstant = 0.15f;
        GameInfo.environment -= environmentalConstant * GameInfo.averageTemperatureChange * GameInfo.environmentResilience;
        
        
        

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
