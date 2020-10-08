using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float health = 100;
    public int moneyValue = 50;
    public GameObject deathEffect;

    [HideInInspector]
    public float speed;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    private void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.Money += moneyValue;
        Destroy(gameObject);
        Destroy(effect, 5f);
    }
}
