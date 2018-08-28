using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerDamageSetter))]
public class PlayerBulletManager : MonoBehaviour
{
    [Header("Shoot Points")]
    public Transform leftShootPoint;
    public Transform rightShootPoint;

    [Header("Bullet")]
    public GameObject bullet;
    public float bulletLaunchVelocity;
    public float bulletLifetime = 3f;

    private SpriteRenderer playerRenderer;
    private PlayerDamageSetter playerDamageSetter;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerDamageSetter = GetComponent<PlayerDamageSetter>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ShootBullet();
    }

    private void ShootBullet()
    {
        Vector3 shootPoint;
        float direction = 1;

        // Shoot from left point
        if (playerRenderer.flipX)
        {
            shootPoint = leftShootPoint.position;
            direction = -1;
        }
        // Shoot from right point
        else
            shootPoint = rightShootPoint.position;

        GameObject bulletInstance = Instantiate(bullet, shootPoint, Quaternion.identity);

        Rigidbody2D bulletRigidbody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bulletLaunchVelocity * direction * Vector2.right;

        bulletInstance.GetComponent<DestroyBullet>().SetBulletLifetime(bulletLifetime);
        playerDamageSetter.ReduceHealth(bulletLifetime);
    }
}
