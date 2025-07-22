using UnityEngine;
using TMPro;
using System;
public class MapRegion : MonoBehaviour
{
    [SerializeField] private string regionName;
    [SerializeField] private float populationInMillions;
    [SerializeField] private float wealthPerCapita;
    [SerializeField] private float emissionsPerCapita;
    [SerializeField] private float temperatureDifferenceFrom15C;
    [SerializeField] private float vulnerability;


    [SerializeField] private TextMeshProUGUI regionNameText;
    [SerializeField] private TextMeshProUGUI regionDescriptionText;


    private SpriteRenderer sr;
    private Texture2D tex;
    private Sprite sprite;


    public float supportLevel;
    public float contributionLevel;
    public int adjustedPopulationInMillions;
    public float adjustedEmissionsPerCapita;
    public float adjustedWealthPerCapita;
    public float adjustedTemperatureDifference;



    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
        tex = sprite.texture;
    }

    void Update()
    {
        if (GameInfo.selectedMapRegion == this)
        {
            Refresh();
        }
        else
        {
            SetColor();
        }
    }
    public void Initialize()
    {
        supportLevel = 80;
        contributionLevel = 1;
        adjustedPopulationInMillions = (int)populationInMillions;
        adjustedEmissionsPerCapita = emissionsPerCapita;
        adjustedWealthPerCapita = wealthPerCapita;
        adjustedTemperatureDifference = temperatureDifferenceFrom15C;


        Tick();


    }

    public void Tick()
    {
        GameInfo.populationInMillions += adjustedPopulationInMillions;
        GameInfo.globalWealth += adjustedWealthPerCapita * contributionLevel * adjustedPopulationInMillions;
        GameInfo.weightedTemperatureChange += adjustedTemperatureDifference * adjustedPopulationInMillions;
        GameInfo.emissionRate += adjustedEmissionsPerCapita * adjustedPopulationInMillions;
        GameInfo.weightedSupportLevel += supportLevel * adjustedPopulationInMillions;
    }

    public void SetColor()
    {
        float t = adjustedTemperatureDifference;
        Color color;

        if (t <= 2.5f)
        {
            // White (0) to Yellow (3)
            float lerpT = Mathf.InverseLerp(0f, 3f, t);
            color = Color.Lerp(Color.white, Color.yellow, lerpT);
        }
        else
        {
            // Yellow (3) to Red (5)
            float lerpT = Mathf.InverseLerp(3f, 5f, t);
            color = Color.Lerp(Color.yellow, Color.red, lerpT);
        }


        color.a = adjustedTemperatureDifference / 5;
        sr.color = color;
    }


    public void Warm(float amount)
    {
        adjustedTemperatureDifference += (vulnerability + 1) * amount;
    }

    public bool IsPixelVisible(Vector2 worldPos)
    {
        Vector2 localPos = transform.InverseTransformPoint(worldPos);

        Vector2 pivot = sprite.pivot;
        float ppu = sprite.pixelsPerUnit;
        Vector2 texCoord = pivot + localPos * ppu;

        int x = Mathf.FloorToInt(texCoord.x);
        int y = Mathf.FloorToInt(texCoord.y);

        if (x < 0 || x >= tex.width || y < 0 || y >= tex.height)
            return false;

        Color pixel = tex.GetPixel(x, y);
        return pixel.a > 0.1f;
    }

    public void Select()
    {
        GameInfo.selectedMapRegion = this;
        //set the selected map region to the clicked region

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.4f);
        regionNameText.text = regionName;

        Refresh();
    }

    public void Refresh()
    {
        string description = "Climate Risk: ";
        if (vulnerability <= 0.3f)
        {
            description += "Low";
        }
        else if (vulnerability >= 0.7f)
        {
            description += "High";
        }
        else
        {
            description += "Medium";
        }
        description += "\n Per Capita Emissions:";
        description += Math.Round((double)adjustedEmissionsPerCapita, 3) + "T/yr";
        description += "\n Temperature Increase:";
        description += Math.Round((double)adjustedTemperatureDifference, 3) + "'C";

        regionDescriptionText.text = description;
    }

    public void Deselect()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        regionNameText.text = "";
    }

    public static void SelectWorld()
    {
        GameInfo.selectedMapRegion = null;
    }

    public float GetWealth()
    {
        return adjustedWealthPerCapita;
    }

    public float GetEmissions()
    {
        return adjustedEmissionsPerCapita;
    }

    public void ReduceEmissions(float amount)
    {
        adjustedEmissionsPerCapita -= amount;
        if (adjustedEmissionsPerCapita < 0)
        {
            adjustedEmissionsPerCapita = 0;
        }
    }

    public int GetPopulation()
    {
        return adjustedPopulationInMillions;
    }

    public string GetName()
    {
        return regionName;
    }
        
    
}




