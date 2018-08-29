using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneOnStart : MonoBehaviour
{
    public Slider loadingSlider;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => StartCoroutine(LoadNextSceneAsync());

    IEnumerator LoadNextSceneAsync()
    {
        int sceneIndex = NextSceneData.nextSceneIndex;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            loadingSlider.value = operation.progress;
            yield return null;
        }
    }
}
