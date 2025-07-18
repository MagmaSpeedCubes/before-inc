using UnityEngine;

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
    }
    public void OnClick()
    {
        if (GameInfo.currency >= policy.GetCost())
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
