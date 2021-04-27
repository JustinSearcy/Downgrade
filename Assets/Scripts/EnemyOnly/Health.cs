using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] GameObject deathEffect;
    [SerializeField] int experienceGiven = 10;
    [SerializeField] int scoreGiven = 100;
    [SerializeField] AudioClip enemyDeath;
    [SerializeField] float enemyDeathVolume = 0.8f;

    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(enemyDeath, transform.position, enemyDeathVolume);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
        FindObjectOfType<CameraShake>().ShakeCamera();
        Destroy(gameObject);
        FindObjectOfType<LevelSystem>().UpdateExperience(experienceGiven);
        if (FindObjectOfType<ScoreTimer>().MultiplierIsActive())
        {
            FindObjectOfType<SessionScore>().AddScore(scoreGiven * 2);
        }
        else
        {
            FindObjectOfType<SessionScore>().AddScore(scoreGiven);
        }
    }

    public void Collide()
    {
        AudioSource.PlayClipAtPoint(enemyDeath, transform.position, enemyDeathVolume);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
        FindObjectOfType<CameraShake>().ShakeCamera();
        Destroy(gameObject);
    }
}
