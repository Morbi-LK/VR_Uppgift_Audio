using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        StartCoroutine(LoadAsyncScene(0));
    }
    public void LoadEscapeRoom()
    {
        StartCoroutine(LoadAsyncScene(1));
    }

    private IEnumerator LoadAsyncScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone) 
        {
            yield return null;
        }
    }
}
