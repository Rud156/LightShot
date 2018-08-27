using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaunchProjectileAnimationEvent : MonoBehaviour
{
    public GameObject projectile;
    public Transform launchPoint;

    public void LaunchProjectile() =>
        Instantiate(projectile, launchPoint.position, projectile.transform.rotation);
}
