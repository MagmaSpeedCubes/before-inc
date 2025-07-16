using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private AudioSource gameAudio;

    private static GameHandler instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple game handlers detected. Destroying duplicate.");
            Destroy(this);
        }
    }
    public void StartGame()
    {
        menuAudio.Stop();
        gameAudio.Play();
    }
}
