using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSelector : MonoBehaviour
{
    public GameObject POVCam;
    public GameObject WorldCam;

    void Start()
    {
        WorldCam.SetActive(false);
    }
    
    void Update()
    {
        
        UpdateCursorLock();
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Build mode
            Constrants.isBuildModeActive = true;
            Constrants.isCursorLocked = false;
            POVCam.SetActive(false);
            WorldCam.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            Constrants.isBuildModeActive = false;
            Constrants.isCursorLocked = true;
            POVCam.SetActive(true);
            WorldCam.SetActive(false);
        }
    }
    
    void UpdateCursorLock()
    {
        if (Constrants.isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
