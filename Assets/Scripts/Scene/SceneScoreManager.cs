using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScoreManager : MonoBehaviour
{
    public Text scoreText;

    private int currentScore;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentScore = 0;
        scoreText.text = $"Score: {currentScore}";
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() => scoreText.text = $"Score: {currentScore}";

    public void IncrementScore(int scoreAmount) => currentScore += scoreAmount;

    public void SaveScore()
    {
        int savedScore = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (PlayerPrefs
            .HasKey($"{ExtensionFunctions.GetPlayerPrefBaseString()}_{currentSceneIndex - 2}_Score")
            )
        {
            savedScore = PlayerPrefs
                .GetInt($"{ExtensionFunctions.GetPlayerPrefBaseString()}_{currentSceneIndex - 2}_Score");
        }

        if (currentScore > savedScore)
        {
            print("Inside If");

            PlayerPrefs
                .SetInt($"{ExtensionFunctions.GetPlayerPrefBaseString()}_{currentSceneIndex - 2}_Score",
                    currentScore);
        }
    }
}
