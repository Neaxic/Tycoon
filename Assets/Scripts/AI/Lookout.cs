using System;
using UnityEngine;

public class Lookout : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    [SerializeField] private float visionDistance;
    [SerializeField] private LineRenderer LOS;
    [SerializeField] private Transform viewPoint;

    private void Update()
    {
        LOS.SetPosition(0, viewPoint.position);
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up);
        
        RaycastHit hit;
        Physics.Raycast(viewPoint.position, transform.forward, out hit, visionDistance);
        if (hit.collider)
        {
            // Debug.DrawLine(viewPoint.position, hit.point, Color.red);
            LOS.SetPosition(1, hit.point);
            if (hit.collider.transform.name != "Player") return;
            print("Player spotted!");
            LOS.startColor = Color.red;
            LOS.endColor = Color.red;
        }
        else
        {
            // Debug.DrawLine(viewPoint.position, viewPoint.position + transform.forward * visionDistance, Color.green);
            LOS.SetPosition(1, viewPoint.position + transform.forward * visionDistance);
            LOS.startColor = Color.green;
            LOS.endColor = Color.green;
        }
    }
}
