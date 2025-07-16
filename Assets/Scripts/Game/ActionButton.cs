using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int unlockStatus;
    //0 = locked
    //1 = unlockable
    //2 = unlocked
    
    [SerializeField] private ActionButton[] prerequisites;
    [SerializeField] private ActionButton[] continuations;




    [SerializeField] private Sprite[] sprites;
    //0 = locked
    //1 = unlockable
    //2 = unlocked

    [SerializeField] private Canvas gameMenu;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private int cost;

    [SerializeField] private float politicalEffect;
    [SerializeField] private float emissionsEffect;
    [SerializeField] private float environmentalEffect;



    void Initialize()
    {
        if (prerequisites.Length == 0)
        {
            unlockStatus = 2;
        }
    }

    void Refresh()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[unlockStatus];


    }

    public void Unlock()
    {
        if (GameInfo.currency >= cost && unlockStatus == 1)
        {
            unlockStatus = 2;
        }
        
    }

    public void OnClick()
    {
        titleText.text = name;
        descriptionText.text = description;
        descriptionText.text += "\n" + cost + " " + GameInfo.currencyUnit;
        GameInfo.selectedActionButton = this;
    }

    
}
