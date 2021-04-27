using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform shotPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] AudioClip playerShoot;
    [SerializeField] [Range(0f, 1f)] float playerShootVolume = 0.6f;

    public float projectileForce = 20f;
    bool isShooting = false;

    Coroutine firingCoroutine;

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firingCoroutine = StartCoroutine(Shoot());
            isShooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(firingCoroutine);
            isShooting = false;
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(shotPoint.up * projectileForce, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(playerShoot, transform.position,playerShootVolume);
            yield return new WaitForSeconds(GetComponent<PlayerStats>().GetProjectileFireRate());
        }
    }

    public bool CheckShooting()
    {
        return isShooting;
    }
}
