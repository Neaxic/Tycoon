using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    public Animator animator;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!Constrants.isBuildModeActive)
        {
            //Controller friendly - read from tutorial
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            float vertialMove = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontalMove, 0, vertialMove);
            //Avoid incresed skrå movement speed w. normilize
            direction.Normalize();

            rig.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime;

            //Animate
            if (direction == Vector3.zero)
            {
                animator.SetFloat("Speed", 0);
            }
            else
            {
                animator.SetFloat("Speed", 1);
            }
        }
        else
        {
            rig.velocity = new Vector3(0, 0, 0);
        }
    }
}