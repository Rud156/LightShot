using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float bulletDamage;
    public GameObject destroyEffect;

    private float bulletLifetime;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => bulletLifetime = -1;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (bulletLifetime == -1)
            return;

        bulletLifetime -= Time.deltaTime;
        if (bulletLifetime <= 0)
            DestroyBulletInstance();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other) => DestroyBulletInstance();

    private void DestroyBulletInstance()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void SetBulletLifetime(float lifeTime) => bulletLifetime = lifeTime;
}
