using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dashSpeed = 1;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int projectileDamage = 100;
    [SerializeField] float projectileFireRate = 0.5f;

    [SerializeField] float moveSpeedReduction = 0.2f;
    [SerializeField] float dashSpeedReduction = 1;
    [SerializeField] int maxHealthReduction = 10;
    [SerializeField] int projectileDamageReduction = 5;

    public float GetMoveSpeed() { return moveSpeed; }

    public float GetDashSpeed() { return dashSpeed; }

    public int GetMaxHealth() { return maxHealth; }

    public int GetProjectileDamage() { return projectileDamage; }

    public float GetProjectileFireRate() { return projectileFireRate; }

    public void LowerStats(int currentLevel)
    {
        maxHealth -= maxHealthReduction;
        dashSpeed -= dashSpeedReduction;
        moveSpeed -= moveSpeedReduction;
        projectileDamage -= projectileDamageReduction;
    }
}
