using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopOnScissorHit : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnBalloonPop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scissors"))
        {
            PopBalloon();
        }
    }

    private void PopBalloon()
    {
        print("Balloon popped!");
        _OnBalloonPop?.Invoke();
    }
}
