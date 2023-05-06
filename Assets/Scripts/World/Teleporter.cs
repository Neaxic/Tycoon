using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    public GameObject telepoint;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && telepoint)
        {
            //Display text usekey to tp
            collider.gameObject.transform.position = telepoint.transform.position;
        }
    }
}
