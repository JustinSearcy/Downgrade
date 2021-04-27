using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthGain = 15;
    [SerializeField] GameObject pickupParticles;
    [SerializeField] AudioClip pickupSound;
    [SerializeField] [Range(0f, 1f)] float pickupSoundVolume = 0.6f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().GainHealth(healthGain);
            GameObject effect = Instantiate(pickupParticles, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, pickupSoundVolume);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
