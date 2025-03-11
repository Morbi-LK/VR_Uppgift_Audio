using System;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public static event Action OnPlayerWon;

    public void PlayerWin()
    {
        OnPlayerWon?.Invoke();
    }
}
