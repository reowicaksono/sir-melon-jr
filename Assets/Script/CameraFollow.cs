using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float orbitDistance = 3.0f;
    public float orbitDegreesPerSec = 360.0f;

    public Vector3 relativeDistance = Vector3.zero;
    public bool once = true;
    // Use this for initialization
    void Start()
    {

        if (target != null)
        {
            relativeDistance = transform.position - target.position;
        }
    }

    void Orbit()
    {
        if (target != null)
        {
            // Keep us at the last known relative position
            transform.position = (target.position + relativeDistance);
            transform.RotateAround(target.position, Vector3.up * Input.GetAxis("Mouse X"), orbitDegreesPerSec * Time.deltaTime);
            // Reset relative position after rotate
            if (once)
            {
                transform.position *= orbitDistance;
                once = false;
            }
            relativeDistance = transform.position - target.position;
        }
    }

    void LateUpdate()
    {

        Orbit();

    }
}
