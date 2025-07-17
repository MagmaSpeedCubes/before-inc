using UnityEngine;
using TMPro;

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


    private float supportLevel;
    private int adjustedPopulationInMillions;
    private float adjustedEmissionsPerCapita;
    private float adjustedWealthPerCapita;
    private float adjustedTemperatureDifference;



    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
        tex = sprite.texture;
    }

    public void Initialize()
    {
        supportLevel = 80;
        adjustedPopulationInMillions = (int)populationInMillions;
        adjustedEmissionsPerCapita = emissionsPerCapita;
        adjustedWealthPerCapita = wealthPerCapita;
        adjustedTemperatureDifference = temperatureDifferenceFrom15C;


        Tick();
        

    }

    public void Tick()
    {
        GameInfo.populationInMillions += adjustedPopulationInMillions;
        GameInfo.globalWealth += adjustedWealthPerCapita * adjustedPopulationInMillions;
        GameInfo.weightedTemperatureChange += adjustedTemperatureDifference * adjustedPopulationInMillions;
        GameInfo.emissionRate += adjustedEmissionsPerCapita * adjustedPopulationInMillions;
        GameInfo.weightedSupportLevel = supportLevel * adjustedPopulationInMillions;
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
}




