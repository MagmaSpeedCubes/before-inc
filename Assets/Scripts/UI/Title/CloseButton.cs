using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class CloseButton : MonoBehaviour
{
    [SerializeField] private bool locked;
    [SerializeField] private Canvas[] hideCanvas;

    private AudioSource audioSource;
    [SerializeField] private AudioClip press;
    [SerializeField] private AudioClip error;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (locked)
        {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void OnClick()
    {
        if (!locked)
        {
            GameInfo.gameSpeed = 1;
            for (int i = 0; i < hideCanvas.Length; i++)
            {
                hideCanvas[i].enabled = false;
            }
            
            audioSource.PlayOneShot(press);

        }
        else
        {
            audioSource.PlayOneShot(error);
        }

    }
}
