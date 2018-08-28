﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSetter : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float maxEnemyHealth = 50;
    public GameObject enemyDestroyEffect;
    public float enemyDamageAmount = 10;

    [Header("Light Stats")]
    public GameObject lightOrbs;
    public int minLightOrbs = 1;
    public int maxLightOrbs = 7;
    public float orbCircleRadius = 5;

    private float currentEnemyHealth;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => currentEnemyHealth = maxEnemyHealth;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (currentEnemyHealth <= 0)
        {
            Instantiate(enemyDestroyEffect, transform.position, Quaternion.identity);

            int randomLightOrbs = Random.Range(minLightOrbs, maxLightOrbs);
            for (int i = 0; i < randomLightOrbs; i++)
            {
                Vector3 randomPointInsideCircle = Random.insideUnitCircle * orbCircleRadius;

                Instantiate(lightOrbs,
                   randomPointInsideCircle + transform.position,
                   Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.Bullet))
        {
            float damageAmount = other.GetComponent<DestroyBullet>().bulletDamage;
            currentEnemyHealth -= damageAmount;
        }
    }
}
