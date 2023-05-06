using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public void TeleportPlayer()
    {
        // Get a reference to the player game object
        GameObject player = GameObject.Find("Player");

        // Check if the player game object exists
        if (player != null)
        {
            // Set the player's position to the TeleportPoint's position
            player.transform.position = transform.position;
        }
    }
}
