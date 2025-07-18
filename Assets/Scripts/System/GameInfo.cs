using UnityEngine;

public class GameInfo
{

    public static int gameSpeed = 1;
    public static GameHandler gameHandler;
    public static string initiativeName = "";

    public static int scenario = 0;
    public static string difficulty = "Base";
    public static float currency = 0;
    public const string currencyUnit = "Funds";


    public static float politicalSensitivity = 1f;

    public static ActionButton selectedActionButton;

    public static MapRegion selectedMapRegion;


    public static float support = 100f;
    public static float carbonInAtmosphere = 1000000f;

    public static float emissionRate = 0f;
    public static float recentTemperatureChange = 0f;
    public static float weightedTemperatureChange;//sum of all regions, needs to be recalculated
    public static float weightedSupportLevel;//sum of all regions, needs to be recalculated
    public static float globalWealth;//sum of all regions, needs to be recalculated
    public static float fundingCoefficient = 0.000002f;
    public static int populationInMillions;
    public static float averageTemperatureChange = 1.5f;

    public static float environment = 100f;

    public static float environmentResilience = 0.5f;

    

    

    


}
