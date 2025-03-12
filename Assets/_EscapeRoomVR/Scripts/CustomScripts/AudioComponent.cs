using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioComponent : MonoBehaviour
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void RegisterMixer(AudioMixerGroup mixer) { _audioSource.outputAudioMixerGroup = mixer; }
    public void RegisterSound(AudioClip clip) => _audioSource.clip = clip;
    public void RelocateComponent(Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    //A bit redunant but can be nice to have access to everything from one source
    public void PlaySound() => _audioSource.Play();
    public void StopSound() => _audioSource.Stop();
}
