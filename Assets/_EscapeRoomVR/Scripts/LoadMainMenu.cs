using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        CountdownTimer.OnRestartGame += ReloadMainMenu;
    }

    private void OnDisable()
    {
        CountdownTimer.OnRestartGame -= ReloadMainMenu;
    }

    private void ReloadMainMenu()
    {
        StartCoroutine(LoadMainMenuAsync());
    }

    private IEnumerator LoadMainMenuAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while(!asyncLoad.isDone) 
        {
            yield return null;
        }
    }
}
