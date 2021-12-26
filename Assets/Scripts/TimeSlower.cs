using System.Collections;
using UnityEngine;

public class TimeSlower
{
    public IEnumerator SlowDownTime()
    {
        SetTimeScale(0.3f);
        yield return new WaitForSeconds(1);
        
        SetTimeScale(0.6f);
        yield return new WaitForSeconds(1);
        
        SetTimeScale(1);
    }

    private void SetTimeScale(float value) => Time.timeScale = value;
}