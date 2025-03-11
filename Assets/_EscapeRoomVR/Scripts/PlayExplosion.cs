using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayExplosion : MonoBehaviour
{
    [SerializeField] private AudioSource _explosionAudioSource;

    private void OnEnable()
    {
        CountdownTimer.OnLoseGame += PlayExplosionSound;
    }

    private void OnDisable()
    {
        CountdownTimer.OnLoseGame -= PlayExplosionSound;
    }

    private void PlayExplosionSound()
    {
        print("Playing explosion");
        _explosionAudioSource.Play();
    }
}
