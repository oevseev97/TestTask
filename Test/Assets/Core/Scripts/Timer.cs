using UnityEngine;
public class Timer 
{
    public float startTime = 0f;

    public float endTime = 0f;

    private float currentTime = 0f;

    public Timer(float _endTime)
    {
        endTime = _endTime;
        startTime = Time.time;
        currentTime = startTime;
    }

    /// <summary>
    /// Returns true if the original time is exceeded.
    /// </summary>
    /// <param name="timeDeltaTime"></param>
    /// <returns></returns>
    public bool ChekTimer()
    {     
        if (currentTime >= startTime + endTime)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Updating the current timer state
    /// </summary>
    public void UpdateTimer(float timeDeltaTime)
    {
        currentTime += timeDeltaTime;
    }

    /// <summary>
    /// Linear dependence from start to end of the timer
    /// </summary>
    public float LerpTimeToStop()
    {
        return Mathf.InverseLerp(startTime, startTime + endTime, currentTime);
    }
}
