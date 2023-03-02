using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 100;
    public int maxHealth = 100;
    public HealthBar HealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetMaxHealth(maxHealth);

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
