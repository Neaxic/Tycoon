using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public static bool isCursorLocked = true;
    //Rotate Player on mouse movement
    public Transform player;
    //Rotate camara not player movement
    public Transform camara;

    public float SensitivtyX;
    public float SensitivtyY;

    public float maxAngle;

    private Quaternion camCenter;
    void Start()
    {
        camCenter = camara.localRotation; //Origin
    }

    void Update()
    {
       SetY();
       SetX();

       UpdateCursorLock();
    }

    void SetY()
    {
        float input = Input.GetAxis("Mouse Y") * SensitivtyY * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, -Vector3.right);
        Quaternion delta = camara.localRotation * adj;

        if (Quaternion.Angle(camCenter, delta) < maxAngle)
        {
            camara.localRotation = delta;
        }
    }
    
    void SetX()
    {
        float input = Input.GetAxis("Mouse X") * SensitivtyX * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, Vector3.up);
        Quaternion delta = player.localRotation * adj;

        player.localRotation = delta;
    }

    void UpdateCursorLock()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isCursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isCursorLocked = true;
            }
        }
    }
}
