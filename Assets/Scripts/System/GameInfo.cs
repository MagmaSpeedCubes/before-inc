using UnityEngine;

public class GameInfo
{
    public static string initiativeName = "";

    public static int scenario = 0;
    public static string difficulty = "Base";
    public static int currency = 0;
    public const string currencyUnit = "Money";


    public static float politicalSensitivity = 1f;

    public static ActionButton selectedActionButton;

    public static MapRegion selectedMapRegion;


    public static float support = 100f;
    public static float carbonInAtmosphere = 1000000f;

    public static float emissionRate = 0f;

}
