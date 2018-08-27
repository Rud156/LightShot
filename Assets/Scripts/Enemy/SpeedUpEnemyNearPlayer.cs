using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpeedUpEnemyNearPlayer : MonoBehaviour
{
    [Header("Stats")]
    public float updatedJumpVelocity;
    public float updatedMovementSpeed;
    public float updatedGravityScale;
    public float maxPlayerDistance;

    private JumpAndMoveEnemy enemyJumper;
    private RollEnemy enemyRoller;

    private float initialMovementSpeed;
    private float initialJumpVelocity;
    private float initialGravityScale;

    private Rigidbody2D enemyRB;
    private Transform player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        enemyJumper = GetComponent<JumpAndMoveEnemy>();
        enemyRoller = GetComponent<RollEnemy>();

        enemyRB = GetComponent<Rigidbody2D>();

        if (enemyJumper != null)
        {
            initialJumpVelocity = enemyJumper.jumpVelocity;
            initialMovementSpeed = enemyJumper.movementSpeed;
        }
        else if (enemyRoller != null)
            initialMovementSpeed = enemyRoller.movementSpeed;

        initialGravityScale = enemyRB.gravityScale;

        player = GameObject.FindGameObjectWithTag(TagManager.Player).transform;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (player == null)
            return;


        if (enemyJumper != null)
            UpdateJumpingEnemy();
        else if (enemyRoller != null)
            UpdateRollingEnemy();
    }

    private void UpdateJumpingEnemy()
    {
        if (Vector2.Distance(transform.position, player.position) > maxPlayerDistance)
        {
            enemyJumper.jumpVelocity = initialJumpVelocity;
            enemyJumper.movementSpeed = initialMovementSpeed;

            enemyRB.gravityScale = initialGravityScale;
        }
        else
        {
            enemyJumper.jumpVelocity = updatedJumpVelocity;
            enemyJumper.movementSpeed = updatedMovementSpeed;

            enemyRB.gravityScale = updatedGravityScale;
        }
    }

    private void UpdateRollingEnemy()
    {
        if (Vector2.Distance(transform.position, player.position) > maxPlayerDistance)
        {
            enemyRoller.movementSpeed = initialMovementSpeed;
            enemyRB.gravityScale = initialGravityScale;
        }
        else
        {
            enemyRoller.movementSpeed = updatedMovementSpeed;
            enemyRB.gravityScale = updatedGravityScale;
        }
    }
}
