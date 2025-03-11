using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayWinSound : MonoBehaviour
{
    [SerializeField] private AudioSource _winAudioSource;

    private void OnEnable()
    {
        CountdownTimer.OnWinGame += PlayWinningSound;
    }

    private void OnDisable()
    {
        CountdownTimer.OnWinGame -= PlayWinningSound;
    }

    private void PlayWinningSound()
    {
        print("Playing win sound");
        _winAudioSource.Play();
    }
}
