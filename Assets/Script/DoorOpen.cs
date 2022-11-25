using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpen = false;
    public GameObject noteUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen == true)
            {
                door.transform.position = new Vector3(8.089f, transform.position.y, transform.position.z);

            }
        }

    }
    private void Start()
    {


        isOpen = false;
        noteUi.SetActive(false);
        door.transform.position = new Vector3(6.009f, transform.position.y, transform.position.z);
    }


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            noteUi.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
            noteUi.SetActive(false);
            
        }
    }
}