using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class goldStatus : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public void SetGold(int gold)
    {
        //Syntax = nice formatting
        goldText.text = $"{gold:n0}";
    }
}
