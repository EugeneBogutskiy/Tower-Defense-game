using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float startHealth = 100f;
    private float health;
    public int damage = 10;
    public int deathReward = 100;

    public Image healthBar;

    public GameObject burstEffect;

    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float value)
    {
        health -= value;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject burstGameObject = Instantiate(burstEffect, transform.position, burstEffect.transform.rotation);
        Destroy(burstGameObject, 2f);
        PlayerStats.gold += deathReward;
        PlayerStats.enemyСounter++;
        Destroy(gameObject);
    }
}
