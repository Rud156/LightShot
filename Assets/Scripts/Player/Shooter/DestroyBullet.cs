using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float bulletDamage;
    public GameObject destroyEffect;

    private float bulletLifetime;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
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

    public void SetBulletLifetime(float lifeTime) => bulletLifetime = lifeTime;
}
