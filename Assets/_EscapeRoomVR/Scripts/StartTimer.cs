using System;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public static event Action _OnTimerStart;

    public void TimerStart()
    {
        _OnTimerStart?.Invoke();
    }
}
