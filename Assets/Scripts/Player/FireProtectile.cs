using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProtectile : MonoBehaviour
{
    public Rigidbody projectile;
    [SerializeField] private Transform gunBarrel;

    public float speed = 4;
    public AudioClip shootingSound;
    private AudioSource audioSource;
    
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = (PlayerPrefs.GetFloat("volume"));
    }

    void Update()
    {
        if (!Constrants.isBuildModeActive)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody p = Instantiate(projectile, gunBarrel.position, transform.rotation);
                p.velocity = transform.forward * speed;
                
                audioSource.PlayOneShot(shootingSound);
            }
        }
    }
}