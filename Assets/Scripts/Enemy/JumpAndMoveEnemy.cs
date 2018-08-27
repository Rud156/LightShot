using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpAndMoveEnemy : MonoBehaviour
{
    public float maxMoveDistance;
    public float jumpVelocity;
    public float movementSpeed;

    private Rigidbody2D enemyRB;

    private float endLeftPosition;
    private float endRightPosition;

    private bool enemyGrounded;
    private bool moveLeft;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        endLeftPosition = transform.position.x - maxMoveDistance;
        endRightPosition = transform.position.x + maxMoveDistance;

        enemyRB = GetComponent<Rigidbody2D>();

        enemyGrounded = false;
        moveLeft = Random.Range(0f, 1f) < 0.5 ? false : true;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
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
            other.gameObject.CompareTag(TagManager.MetalGround) ||
            other.gameObject.CompareTag(TagManager.Player))
            enemyGrounded = true;
    }

    private void HorizontalMovement()
    {
        if (transform.position.x < endLeftPosition)
        {
            moveLeft = false;
            enemyRB.velocity = Vector2.zero;
            transform.position = new Vector2(endLeftPosition, transform.position.y);
        }
        else if (transform.position.x > endRightPosition)
        {
            moveLeft = true;
            enemyRB.velocity = Vector2.zero;
            transform.position = new Vector2(endRightPosition, transform.position.y);
        }

        if (moveLeft)
            enemyRB.velocity = Vector2.up * enemyRB.velocity.y +
                Vector2.left * movementSpeed * Time.deltaTime;
        else
            enemyRB.velocity = Vector2.up * enemyRB.velocity.y +
                    Vector2.right * movementSpeed * Time.deltaTime;
    }

    private void VerticalMovement()
    {
        if (!enemyGrounded)
            return;

        enemyRB.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        enemyGrounded = false;
    }
}
