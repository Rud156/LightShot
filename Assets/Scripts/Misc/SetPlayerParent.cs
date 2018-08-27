using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerParent : MonoBehaviour
{
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.Player))
            other.transform.SetParent(gameObject.transform);
    }

    /// <summary>
    /// Sent when a collider on another object stops touching this
    /// object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.Player))
            other.transform.SetParent(null);
    }
}
