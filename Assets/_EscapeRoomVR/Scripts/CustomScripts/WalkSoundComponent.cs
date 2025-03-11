using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class WalkSoundComponent : MonoBehaviour
{
    [SerializeField] private bool Walking = false;

    [SerializeField] private DynamicMoveProvider moveProvider;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        moveProvider.MoveStart += StartWalk;
        moveProvider.MoveEnd += WalkEnd;
    }

    private void OnDestroy()
    {
        moveProvider.MoveStart -= StartWalk;
        moveProvider.MoveEnd -= WalkEnd;
    }

    void StartWalk() 
    {
        Walking = true;
        _audioSource.Play();
    }

    private void WalkEnd() 
    {
        Walking = false;
        _audioSource.Stop();
    }
}
