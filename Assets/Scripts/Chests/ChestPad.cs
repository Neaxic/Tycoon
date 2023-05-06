using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPad : MonoBehaviour
{
    // Start is called before the first frame update
    public chestUnlocker chest;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chest.chestPadPress();
        }
    }
}
