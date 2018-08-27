using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileOnContact : MonoBehaviour
{
    public float minDamageAmount = 20;
    public float maxDamageAmount = 30;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other) => Destroy(gameObject);

    public float GetDamageAmount() => Random.Range(minDamageAmount, maxDamageAmount);

}
