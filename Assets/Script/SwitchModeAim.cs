using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModeAim : MonoBehaviour
{
    public Transform tpscanvas;
    public Transform aimcanvas;
    public Transform tpscam;
    public Transform aimcam;    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            tpscanvas.gameObject.SetActive(false);
            aimcanvas.gameObject.SetActive(true);
            tpscam.gameObject.SetActive(false);
            aimcam.gameObject.SetActive(true);
        }
        else
        {
            tpscanvas.gameObject.SetActive(true);
            aimcanvas.gameObject.SetActive(false);
            tpscam.gameObject.SetActive(true);
            aimcam.gameObject.SetActive(false);
        }
    }
}
