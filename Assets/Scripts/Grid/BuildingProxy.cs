using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProxy : MonoBehaviour
{
    public BuildingSystem buildingSystem;
    public Player player;

    
    public bool canAfford(int price)
    {
        if (player.gold >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void purchase(int index, int price)
    {
        if (canAfford(price))
        {
            player.UseGold(price);
            buildingSystem.SetPrefabIndex(index);
        }
    }
}
