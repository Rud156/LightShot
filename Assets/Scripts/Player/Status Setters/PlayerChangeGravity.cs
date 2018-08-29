using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerChangeGravity : MonoBehaviour
{
    [Range(3, 7)]
    public int reducedGravity = 5;

    private Rigidbody2D playerRB;
    private bool gravitySwitchCollected;
    private float initialGravity;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        gravitySwitchCollected = false;
        initialGravity = playerRB.gravityScale;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ToggleGravity();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.GravityChanger))
            gravitySwitchCollected = true;
    }

    private void ToggleGravity()
    {
        if (!gravitySwitchCollected)
            return;

        float currentGravity = playerRB.gravityScale;
        if (currentGravity == initialGravity)
            playerRB.gravityScale = reducedGravity;
        else
            playerRB.gravityScale = initialGravity;
    }
}
