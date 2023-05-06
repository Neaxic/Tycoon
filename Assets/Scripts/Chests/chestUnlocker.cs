using System;
using System.Collections;
using System.Collections.Generic;
using Chests;
using UnityEngine;
using TMPro;

public class chestUnlocker : MonoBehaviour, IChestUnlocker
{

    public bool isLocked = true;
    public string name = "SILVER";
    public int cost = 1000;
    public GameObject chestTop;
    public GameObject chestPad; // Knappen foran
    public TextMeshProUGUI   chestText;
    public GameObject moneySpawner; //Spawnern skal være hidden når locked

    public void Start()
    {
        chestText.text = name + " CRATE \n "+cost+" TO UNLOCK";
        if (isLocked)
        {
            moneySpawner.SetActive(false);
        };
    }
    
    public void unlockChest()
    {
        if (isLocked)
        {   
            moneySpawner.SetActive(true);
            chestTop.transform.Rotate(new Vector3(-75, 0, 0));
            isLocked = false;
        }
    }

    public void chestPadPress()
    {
        if (isLocked)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p.GetComponent<Player>().gold >= cost)
            {
                p.GetComponent<Player>().UseGold(cost);
                unlockChest();
            }
            else
            {
                //Not enough money et eller andet
            }
        }
        //Upgrade stuff?
    }
    
}
