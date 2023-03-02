using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health = 100;
    public int maxHealth = 100;
    public HealthBar HealthBar;
    void Start()
    {
        HealthBar.SetMaxHealth(maxHealth);
        HealthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Damage(int dmg)
    {
        health -= dmg;
        HealthBar.SetHealth(health);

        if (health < 0)
        {
            Debug.Log("idk yet");
        }
    }
}
