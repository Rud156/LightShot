using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileOnContactPlayer : MonoBehaviour
{
    public float minDamageAmount = 20;
    public float maxDamageAmount = 30;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => Destroy(gameObject, 10f);

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Player))
            Destroy(gameObject);
    }

    public float GetDamageAmount() => Random.Range(minDamageAmount, maxDamageAmount);
}
