using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioComponent : MonoBehaviour
{
    private AudioSource _audioScource;

    void Awake()
    {
        _audioScource = GetComponent<AudioSource>();
    }

    public void RegisterSound(AudioClip clip) => _audioScource.clip = clip;
    public void RelocateComponent(Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    //A bit redunant but can be nice to have access to everything from one source
    public void PlaySound() => _audioScource.Play();
    public void StopSound() => _audioScource.Stop();
}
