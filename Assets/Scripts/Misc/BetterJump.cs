using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

    [Header("Jump Fall Rates")]
    public float fallMultiplier = 2.5f;

    private Rigidbody2D playerRB;

    // Use this for initialization
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (playerRB.velocity.y < 0)
            playerRB.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
}
