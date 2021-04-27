using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float followSpeed = 4f;
    [SerializeField] int enemyDamage = 10;
    Transform target;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, followSpeed * Time.deltaTime);
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            if(FindObjectOfType<UICanvas>() != null)
            {
                FindObjectOfType<UICanvas>().UpdateHealth();
                GetComponent<Health>().Collide();
            }
        }
    }
}
