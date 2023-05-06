using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class buildableToggle : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public int price;
    public Image selectedCheck;
    public int index;
    public BuildingSystem buildingSystem;
    public BuildingProxy buildingProxy;

    private Toggle togglerItself;

    void Start()
    {
        priceText.text = ""+price;
        //Fetch the Toggle GameObject
        togglerItself = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        togglerItself.onValueChanged.AddListener(delegate {
            ToggleValueChanged(togglerItself);
        });
        selectedCheck.enabled = false;
    }
    
    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            //Price check - in purchase proxy
            if (buildingProxy.canAfford(price))
            {
                buildingProxy.purchase(index, price);
                selectedCheck.enabled = true;
            }
            else
            {
                selectedCheck.enabled = false;
            }
        }
        else
        {
            selectedCheck.enabled = false;
        }
    }

}
