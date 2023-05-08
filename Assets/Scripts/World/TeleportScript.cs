using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public void TeleportPlayer()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            player.transform.position = transform.position;
        }
    }
}
