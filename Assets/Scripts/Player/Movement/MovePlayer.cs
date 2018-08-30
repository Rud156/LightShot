using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed;
    public float jumpVelocity;
    public float fallThresholdVelocity;

    [Header("Jump Dust")]
    public GameObject groundDust;
    public Transform dustSpawnPoint;

    private Rigidbody2D playerRB;
    private SpriteRenderer playerRenderer;

    private bool playerGrounded;

    // Use this for initialization
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerRB = GetComponent<Rigidbody2D>();

        playerGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();

        CheckFalling();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.GrassGround) ||
            other.gameObject.CompareTag(TagManager.LavaGround) ||
            other.gameObject.CompareTag(TagManager.WaterGround) ||
            other.gameObject.CompareTag(TagManager.MetalGround))
        {
            Instantiate(groundDust, dustSpawnPoint.transform.position, groundDust.transform.rotation);
            playerGrounded = true;
        }
    }

    private void HorizontalMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        playerRB.velocity = Vector2.up * playerRB.velocity.y +
            Vector2.right * moveX * moveSpeed * Time.deltaTime;

        if (moveX < 0)
            playerRenderer.flipX = true;
        else if (moveX > 0)
            playerRenderer.flipX = false;
    }

    private void VerticalMovement()
    {
        if (!playerGrounded)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            playerGrounded = false;
        }
    }

    private void CheckFalling()
    {
        if (playerRB.velocity.y < -fallThresholdVelocity)
            playerGrounded = false;
    }
}
