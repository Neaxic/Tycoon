using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI healthText;
    private int maxHealth;
    private int currHealth;
    void Start()
    {
        currHealth = maxHealth;
        healthText.text = "" + currHealth + " / " + maxHealth;
    }
    
    public void SetHealth(int health)
    {
        currHealth = health;
        refreshText();
    }
    
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        refreshText();
    }

    private void refreshText()
    {
        healthText.text = "" + currHealth + " / " + maxHealth;
    }


}
