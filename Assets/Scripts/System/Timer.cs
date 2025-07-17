using System.Collections;
using UnityEngine;
using System.Reflection;

public class Timer : MonoBehaviour
{
    [SerializeField] private float secondsPerTimeUnit = 1f;
    private static float time = 0f;
    private static bool active = false;
    private static int lastTick = 0;

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
        if (lastTick < time + 1)
        {
            GameInfo.gameHandler.Tick();
            lastTick += 1;
        }

    }

    public static void StartTimer()
    {
        active = true;
    }

    public static void StopTimer()
    {
        active = false;
    }

    public static void ResetTimer()
    {
        time = 0f;
    }

    public static void SetTime(float newTime)
    {
        time = newTime;
    }

    public static float GetTime()
    {
        return time;
    }


    public static bool IsRunning()
    {
        return active;
    }


}
