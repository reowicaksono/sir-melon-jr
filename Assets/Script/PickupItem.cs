using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public GameObject tasbih;
    public GameObject magicItem;
    public GameObject text3d;

    public PlayerScript player;
    private float radiusItem = 2.5f;
    public bool isPickup = false;
    // Start is called before the first frame update
    private void Awake()
    {
        tasbih.SetActive(false);
    }
    private void Start() 
    {
        text3d.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radiusItem)
        {
            text3d.SetActive(true);
           
            if (Input.GetKeyDown("f"))
            {
                isPickup = true;
                tasbih.SetActive(true);
                magicItem.SetActive(false);
                text3d.SetActive(false);
                // Debug.Log(isPickup);
                 Mission.objek.getDataMission(true,false);
            }
        }else{
            text3d.SetActive(false);
        }
    }
}
