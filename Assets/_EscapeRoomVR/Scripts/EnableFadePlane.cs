using UnityEngine;

public class EnableFadePlane : MonoBehaviour
{
    [SerializeField] private GameObject _fadePlane;

    private void OnEnable()
    {
        CountdownTimer.OnLoseGame += ActivateFadePlane;
        CountdownTimer.OnWinGame += ActivateFadePlane;
    }

    private void OnDisable()
    {
        CountdownTimer.OnLoseGame -= ActivateFadePlane;
        CountdownTimer.OnWinGame -= ActivateFadePlane;
    }

    private void Start()
    {
        if (!_fadePlane.activeSelf)
        {
            _fadePlane.SetActive(false);
        }
    }

    private void ActivateFadePlane()
    {
        _fadePlane.SetActive(true);
    }
}
