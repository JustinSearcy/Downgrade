using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] float followSpeed = 4f;
    [SerializeField] int enemyDamage = 10;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float enemyProjectileForce = 8f;
    [SerializeField] float enemyRange = 5f;
    [SerializeField] float enemyShootDelay = 0.5f;
    [SerializeField] Transform shotPoint;

    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if(distanceToPlayer > enemyRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, followSpeed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(enemyShootDelay);
        GameObject projectile = Instantiate(enemyProjectile, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(target.position * enemyProjectileForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(enemyDamage);
            FindObjectOfType<UICanvas>().UpdateHealth();
            GetComponent<Health>().Die();
        }
    }
}
