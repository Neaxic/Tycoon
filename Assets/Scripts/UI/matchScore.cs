using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class matchScore : MonoBehaviour
{
    public TextMeshProUGUI MatchState;
    public TextMeshProUGUI EnemiesRemaing;
    public TextMeshProUGUI TimeRemaing;
    
    public void SetMatchState(string state)
    {
        MatchState.text = ""+state;
    }
    
    public void SetEnemiesRemaing(int enemies)
    {
        EnemiesRemaing.text = ""+enemies;
    }
    
    public void SetTimeRemaing(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float secounds = Mathf.FloorToInt(time % 60);

        TimeRemaing.text = ""+minutes+":"+secounds;
    }
}
