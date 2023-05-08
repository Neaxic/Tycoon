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

    private float damageInterval = 5f; 
    private float timer = 0f; 

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
                Damage(1);
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
            timer = damageInterval; 
            Damage(enemy.damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            timer = 0f;
        }
    }
}