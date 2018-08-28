using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnPlayerDead : MonoBehaviour
{
    public float waitTimeForSceneChange = 1.5f;
    public PlayerDamageSetter playerDamageSetter;
    public Animator displayTextAnimator;
    public Text displayText;

    private bool playerDeadTrigger;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => playerDeadTrigger = false;


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (playerDamageSetter.GetCurrentHealth() <= 0 && !playerDeadTrigger)
        {
            playerDeadTrigger = true;
            StartCoroutine(DisplayTextAndChangeScene());
        }
    }

    private IEnumerator DisplayTextAndChangeScene()
    {
        displayText.text = "You Were Killed in Action";
        displayText.color = Color.red;
        displayTextAnimator.SetTrigger(AnimatorVariables.DisplayText);

        yield return new WaitForSeconds(waitTimeForSceneChange);

        SceneManager.LoadScene(1);
    }
}
