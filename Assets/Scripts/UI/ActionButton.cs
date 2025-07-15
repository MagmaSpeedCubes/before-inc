using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private bool unlocked;
    [SerializeField] private int cost;
    [SerializeField] private ActionButton[] prerequisites;
    [SerializeField] private ActionButton[] continuations;
    [SerializeField] private Sprite[] sprites;
    //0 = locked
    //1 = unlockable
    //2 = unlocked

    [SerializeField] private Canvas gameMenu;

    void Initialize()
    {
        if (prerequisites.Length == 0)
        {
            unlocked = true;
        }
    }

    void Refresh()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (unlocked)
        {
            spriteRenderer.sprite = sprites[2];
        }

    }

    public void Unlock()
    {

    }

    public void OnClick()
    {
        
    }

    
}
