using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelectorManager : MonoBehaviour
{
    [System.Serializable]
    public struct SceneSelector
    {
        public RawImage levelImage;
        public Text scoreText;
    };

    public List<SceneSelector> sceneSelectors;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < sceneSelectors.Count; i++)
        {
            if (PlayerPrefs.HasKey($"{ExtensionFunctions.GetPlayerPrefBaseString()}_{i + 1}"))
                sceneSelectors[i].levelImage.color = Color.green;

            if (PlayerPrefs.HasKey($"{ExtensionFunctions.GetPlayerPrefBaseString()}_{i + 1}_Score"))
            {
                int savedScore = PlayerPrefs
                    .GetInt($"{ExtensionFunctions.GetPlayerPrefBaseString()}_{i + 1}_Score");

                sceneSelectors[i].scoreText.text = $"Score - {savedScore}";
            }
            else
                sceneSelectors[i].scoreText.text = "Score - 0";
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
