using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    
    void Start()
    {
        Camera.main.enabled = false;
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Controller friendly - read from tutorial
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float vertialMove = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalMove, 0, vertialMove);
        //Avoid incresed skrå movement speed w. normilize
        direction.Normalize();

        rig.velocity = transform.TransformDirection(direction ) * speed * Time.deltaTime;
        

    }
}
