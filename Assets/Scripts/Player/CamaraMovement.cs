using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
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
        if (!Constrants.isBuildModeActive)
        {
            SetY();
            SetX();
        }
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

    
}
