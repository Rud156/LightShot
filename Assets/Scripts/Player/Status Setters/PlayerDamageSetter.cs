﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageSetter : MonoBehaviour
{
    public float maxPlayerHealth;
    public GameObject playerDeathEffect;

    [Header("Health Display")]
    public Color minHealthColor = Color.red;
    public Color halfHealthColor = Color.yellow;
    public Color maxHealthColor = Color.green;
    public Slider healthSlider;
    public Image healthFiller;

    private float currentHealth;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => currentHealth = maxPlayerHealth;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        UpdateHealthToUI();
        CheckHealthZero();
    }

    /// <summary>
    /// OnParticleCollision is called when a particle hits a collider.
    /// </summary>
    /// <param name="other">The GameObject hit by the particle.</param>
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(TagManager.GroundShooter))
            currentHealth -= DamageData.GetGroundShooterDamage();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.WallShooter))
            currentHealth -= other.GetComponent<DestroyProjectileOnContact>().GetDamageAmount();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.Enemy))
            currentHealth -= other.gameObject.GetComponent<EnemyDamageSetter>().enemyDamageAmount;
    }

    private void UpdateHealthToUI()
    {
        float maxHealth = maxPlayerHealth;
        float currentHealthLeft = currentHealth;
        float healthRatio = currentHealthLeft / maxHealth;

        if (healthRatio <= 0.5)
            healthFiller.color = Color.Lerp(minHealthColor, halfHealthColor, healthRatio * 2);
        else
            healthFiller.color = Color.Lerp(halfHealthColor, maxHealthColor, (healthRatio - 0.5f) * 2);
        healthSlider.value = healthRatio;
    }

    private void CheckHealthZero()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(float healthAmount)
    {
        if (currentHealth + healthAmount > maxPlayerHealth)
            currentHealth = maxPlayerHealth;
        else
            currentHealth += healthAmount;
    }

    public void ReduceHealth(float healthAmount) => currentHealth -= healthAmount;
}
