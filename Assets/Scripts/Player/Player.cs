using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int gold = 1000;
    public int health = 100;
    public int maxHealth = 100;
    public healthStatus HealthStatus;
    public goldStatus GoldStatus;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthStatus.SetMaxHealth(maxHealth);
        HealthStatus.SetHealth(maxHealth);
        GoldStatus.SetGold(gold);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dmgTest")
        {
            Damage(10);
        }
        if (collision.gameObject.tag == "Zombie")
        {
            Damage(50);
        }
        if (collision.gameObject.tag == "nogoZone")
        {
            Damage(100);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        HealthStatus.SetHealth(health);

        if (health <= 0)
        {
            Destroy(player);
        }
    }

    public void EarnGold(int gold)
    {
        this.gold += gold;
        GoldStatus.SetGold(this.gold);
    }

    public bool UseGold(int gold)
    {
        if (this.gold - gold > 0)
        {
        this.gold -= gold;
        GoldStatus.SetGold(this.gold);
        return true;
        }
        else
        {
            return false;
        }

        }
}
