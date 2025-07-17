using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    public int unlockStatus;
    //0 = locked
    //1 = unlockable
    //2 = unlocked
    
    [SerializeField] private ActionButton[] prerequisites;
    [SerializeField] private ActionButton[] mutuallyExclusive;
    [SerializeField] private ActionButton[] continuations;

    [SerializeField] private Image tile;
    [SerializeField] private Image icon;




    [SerializeField] private Sprite[] sprites;
    //0 = locked
    //1 = unlockable
    //2 = unlocked

    [SerializeField] private Canvas gameMenu;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private int cost;

    [SerializeField] private float politicalEffect;
    [SerializeField] private float emissionsEffect;
    [SerializeField] private float environmentalEffect;

    private bool localGameActive = false;

    void Update()
    {
        if (Timer.IsRunning() != localGameActive)
        {
            localGameActive = Timer.IsRunning();
            if (localGameActive)
            {
                Initialize();
            }
        }
        else
        {
            Refresh();
        }
        
    }

    void Initialize()
    {


        if (prerequisites.Length == 0)
        {
            unlockStatus = 1;

        }

        Refresh();
        


    }

    public void Refresh()
    {
        if (unlockStatus == 0)
        {
            bool unlockable = true;
            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (prerequisites[i].unlockStatus != 2)
                {
                    unlockable = false;
                }
            }
            if (unlockable)
            {
                unlockStatus = 1;
                icon.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                icon.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        
        tile.sprite = sprites[unlockStatus];


    }

    public void Unlock()
    {
        unlockStatus = 2;

        
    }

    public void OnClick()
    {
        if (unlockStatus != 0)
        {
            titleText.text = name;
            descriptionText.text = description;
            costText.text = "Fund\n" + cost + " " + GameInfo.currencyUnit;
            GameInfo.selectedActionButton = this;
        }

    }

    
}
