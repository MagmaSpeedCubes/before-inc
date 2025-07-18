using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TicksToDate :  MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;
    private string[] monthPrefixes = new string[]
    {
        "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
    };

    [SerializeField] private int startingYear = 2025;

    void Update()
    {
        int currentTick = (int)Timer.GetTime();
        int month = currentTick % 12;
        clock.text = monthPrefixes[month];
        int years = (currentTick - month) / 12 + startingYear;
        clock.text += " " + years;
    }
}
