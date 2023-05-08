using System.Collections;
using System.Collections.Generic;
using Chests;
using UnityEngine;

public class ChestPad : MonoBehaviour
{
    public IChestUnlocker chest;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chest.chestPadPress();
        }
    }
}
