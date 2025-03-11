using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public static event Action _OnWrongAnswer;

    public void WrongAnswerEntered()
    {
        _OnWrongAnswer?.Invoke();
    }
}
