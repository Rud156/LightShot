using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{
    public List<RawImage> levelImages;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < levelImages.Count; i++)
        {
            if (PlayerPrefs.HasKey($"{ExtensionFunctions.GetPlayerPrefBaseString()}_${i + 1}"))
                levelImages[i].color = Color.green;
        }
    }

    public void LoadScene_1() => LoadScene(3);
    public void LoadScene_2() => LoadScene(4);
    public void LoadScene_3() => LoadScene(5);
    public void LoadScene_4() => LoadScene(6);
    public void LoadScene_5() => LoadScene(7);
    public void LoadScene_6() => LoadScene(8);
    public void LoadScene_7() => LoadScene(9);

    public void GoToHomeScreen() => SceneManager.LoadScene(0);

    private void LoadScene(int sceneIndex)
    {
        NextSceneData.nextSceneIndex = sceneIndex;
        SceneManager.LoadScene(2);
    }
}
