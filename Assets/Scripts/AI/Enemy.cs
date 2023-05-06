using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damage = 10;
    public int health = 100;
    public int maxHealth = 100;
    public HealthBar HealthBar;
    public float middleY;
    
    void Start()
    {
        HealthBar.SetMaxHealth(maxHealth);
        HealthBar.SetHealth(health);
        
        //Udregn middleY - lidt et hack for turret kan finde midten idk men det virker
        Renderer renderer = GetComponentInChildren<Renderer>();
        Bounds bounds = renderer.bounds;
        middleY = bounds.center.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            Damage(projectile.damage);
        }
    }
    
    public void Damage(int dmg)
    {
        health -= dmg;
        HealthBar.SetHealth(health);

        if (health < 0)
        {
            Destroy(gameObject);
            Debug.Log("idk yet");
        }
    }
}
