using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float secondsPerTimeUnit = 1f;
    private float time = 0f;
    private bool active = false;

    public static Timer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple timer instances detected. Destroying duplicate.");
            Destroy(this);
        }
    }
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime / secondsPerTimeUnit;
        }

    }

    public void StartTimer()
    {
        active = true;
    }

    public void StopTimer()
    {
        active = false;
    }

    public void ResetTimer()
    {
        time = 0f;
    }

    public void SetTime(float newTime)
    {
        time = newTime;
    }

    public float GetTime()
    {
        return time;
    }


}
