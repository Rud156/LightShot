using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ChangeSceneOnTrigger : MonoBehaviour
{
    public Animator displayTextAnimator;
    public Text displayText;
    public float waitTimeForSceneChange = 1.5f;

    private AudioSource portalAudio;
    private bool playerTriggered;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        portalAudio = GetComponent<AudioSource>();
        playerTriggered = false;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Player) && !playerTriggered)
            StartCoroutine(ChangeSceneOnPortal());
    }

    private IEnumerator ChangeSceneOnPortal()
    {
        portalAudio.Play();

        displayText.text = "You Completed the Level !!!";
        displayText.color = Color.green;
        displayTextAnimator.SetTrigger(AnimatorVariables.DisplayText);

        yield return new WaitForSeconds(waitTimeForSceneChange);

        SceneManager.LoadScene(1);

    }
}
