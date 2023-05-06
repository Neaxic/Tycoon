using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityDeletor : MonoBehaviour
{
    public int entityWorth = 0;
    public Player player;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            player.EarnGold(entityWorth);
            Destroy(collision.gameObject);
        }
    }
}
