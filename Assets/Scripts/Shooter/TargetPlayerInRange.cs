using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerInRange : MonoBehaviour
{
    [Header("Player Stats")]
    public Transform playerTransform;
    public float maxDistanceToTarget;

    [Header("Projectile Stats")]
    public GameObject projectile;
    public Transform launchPoint;
    public float projectileLaunchSpeed;
    public float waitBetweenShots;

    private Coroutine coroutine;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => coroutine = StartCoroutine(ShootPlayer());

    public void StopShooting() => StopCoroutine(coroutine);

    IEnumerator ShootPlayer()
    {
        while (true)
        {
            if (playerTransform != null)
                CheckAndShootPlayer();

            yield return new WaitForSeconds(waitBetweenShots);
        }
    }

    private void CheckAndShootPlayer()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance > maxDistanceToTarget)
            return;

        Vector2 direction = playerTransform.position - transform.position;
        GameObject projectileInstance = Instantiate(projectile, launchPoint.position, Quaternion.identity);
        projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileLaunchSpeed;
    }
}
