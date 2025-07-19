using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class BuyButton : MonoBehaviour
{
    public ActionButton policy;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip press;
    [SerializeField] private AudioClip error;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        policy = GameInfo.selectedActionButton;
        if (policy != null)
        {
            if (GameInfo.currency >= policy.GetCost() && policy.unlockStatus != 2)
            {
                GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }
    }
    public void OnClick()
    {
        if (GameInfo.currency >= policy.GetCost() && policy.unlockStatus != 2)
        {
            GameInfo.currency -= policy.GetCost();
            policy.Unlock();
            audioSource.PlayOneShot(press);
        }
        else
        {
            audioSource.PlayOneShot(error);
        }
    }
}
