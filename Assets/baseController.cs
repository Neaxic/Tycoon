using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baseController : MonoBehaviour
{
    public int health = 3000;
    public int maxHealth = 3000;
    public healthStatus HealthStatus;
    public HealthBar HealthBar;

    private float damageInterval = 5f; // how often the base takes damage
    private float timer = 0f; // timer to track when to apply damage

    void Start()
    {
        HealthBar.SetMaxHealth(maxHealth);
        HealthBar.SetHealth(health);
        HealthStatus.SetMaxHealth(maxHealth);
        HealthStatus.SetHealth(maxHealth);
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                Damage(1); // base takes 1 damage every 5 seconds while an enemy is inside its collision box
                timer = damageInterval;
            }
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        HealthStatus.SetHealth(health);
        HealthBar.SetHealth(health);
        
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game over!");
            SceneManager.LoadScene(0);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            timer = damageInterval; // start the damage timer when an enemy enters the collision box
            Damage(enemy.damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            timer = 0f; // stop the damage timer when an enemy exits the collision box
        }
    }
}