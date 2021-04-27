using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    [SerializeField] AudioClip playerDeath;
    [SerializeField] float playerDeathVolume = 0.8f;
    [SerializeField] AudioClip playerHit;
    [SerializeField] float playerHitVolume = 0.8f;

    int currentHealth;
    private void Awake()
    {
        currentHealth = GetComponent<PlayerStats>().GetMaxHealth();
    }

    private void Update()
    {
        if (currentHealth > GetComponent<PlayerStats>().GetMaxHealth())
        {
            currentHealth = GetComponent<PlayerStats>().GetMaxHealth();
            FindObjectOfType<UICanvas>().UpdateHealth();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            FindObjectOfType<UICanvas>().UpdateHealth();
            Die();
        }
        else
        {
            AudioSource.PlayClipAtPoint(playerHit, transform.position, playerHitVolume);
        }
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(playerDeath, transform.position, playerDeathVolume);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        FindObjectOfType<PlayerDeath>().Die();
        FindObjectOfType<CameraShake>().ShakeCamera();
        Destroy(gameObject);
    }

    public int GetHealth() { return currentHealth; }

    public void GainHealth(int healthGained)
    {
        if (healthGained + currentHealth >= GetComponent<PlayerStats>().GetMaxHealth())
        {
            currentHealth = GetComponent<PlayerStats>().GetMaxHealth();
        }
        else
        {
            currentHealth += healthGained;
        }
        FindObjectOfType<UICanvas>().UpdateHealth();
    }
}
