using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RollEnemy : MonoBehaviour
{
    public float maxMoveDistance;
    public float movementSpeed;

    private Rigidbody2D enemyRB;

    private float endLeftPosition;
    private float endRightPosition;

    private bool moveLeft;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();

        endLeftPosition = transform.position.x - maxMoveDistance;
        endRightPosition = transform.position.x + maxMoveDistance;

        moveLeft = Random.Range(0f, 1f) < 0.5 ? false : true;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() => HorizontalMovement();

    private void HorizontalMovement()
    {
        if (transform.position.x < endLeftPosition)
        {
            moveLeft = false;
            transform.position = new Vector2(endLeftPosition, transform.position.y);

            enemyRB.velocity = Vector2.zero;
            enemyRB.angularVelocity = 0;
        }
        else if (transform.position.x > endRightPosition)
        {
            moveLeft = true;
            transform.position = new Vector2(endRightPosition, transform.position.y);

            enemyRB.velocity = Vector2.zero;
            enemyRB.angularVelocity = 0;
        }

        if (moveLeft)
            enemyRB.velocity = Vector2.up * enemyRB.velocity.y +
                Vector2.left * movementSpeed * Time.deltaTime;
        else
            enemyRB.velocity = Vector2.up * enemyRB.velocity.y +
                Vector2.right * movementSpeed * Time.deltaTime;
    }
}
