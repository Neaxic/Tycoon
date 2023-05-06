using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildUI : MonoBehaviour
{
    public Image panel;
    void Start()
    {
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Constrants.isBuildModeActive)
        {
            panel.gameObject.SetActive(true);
        }
        
        if (!Constrants.isBuildModeActive)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
