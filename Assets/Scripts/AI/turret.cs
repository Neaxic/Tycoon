using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public float range = 10f; 
    public Transform target; 
    public Vector3 targetPos;
    public float turnSpeed = 5f; 
    public Rigidbody projectile; 
    public Transform gunBarrel; 
    public float shootDelay = 1f;
    public int damage = 10;
    private float nextShotTime; 
    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

        float closestDistance = Mathf.Infinity;
        Transform closestZombie = null;

        foreach (GameObject zombie in zombies)
        {
            float distance = Vector3.Distance(transform.position, zombie.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestZombie = zombie.transform;
            }
        }

        if (closestZombie != null && closestDistance <= range)
        {
            target = closestZombie;
            targetPos = closestZombie.position;
        }

        if (target)
        {
            TurnTowards(targetPos - transform.position);
            if (Time.time < nextShotTime) return;
            Rigidbody p = Instantiate(projectile, gunBarrel.position, transform.rotation);
            p.GetComponent<Projectile>().damage = damage;
            p.velocity = transform.forward * speed;
            nextShotTime = Time.time + shootDelay;
            
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector3 aimPos = new Vector3(transform.position.x, enemy.middleY, transform.position.z);
                gunBarrel.LookAt(aimPos);
            }
            else
            {
                // If the target doesn't have the Enemy script, just aim at its center
                gunBarrel.LookAt(target);
            }
        }
    }

    private void TurnTowards(Vector3 direction)
    {
        var horizontalDirection = new Vector3(direction.x, 0f, direction.z);
        var horizontalRotation = Quaternion.LookRotation(horizontalDirection);
    
        var verticalAngle = Vector3.Angle(direction, horizontalDirection);
        var verticalDirection = Quaternion.AngleAxis(verticalAngle, Vector3.right) * Vector3.forward;

        var newDirection = horizontalRotation * verticalDirection;
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
