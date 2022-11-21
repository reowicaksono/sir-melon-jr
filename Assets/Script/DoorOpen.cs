using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpen = false;


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                door.transform.position = new Vector3(5.089f, transform.position.y, transform.position.z);
            }
            else
            {
                door.transform.position = new Vector3(4.009f, transform.position.y, transform.position.z);
            }

        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E)) isOpen = true;
        isOpen = Input.GetKey(KeyCode.E) ? isOpen = true : isOpen = false;
        Debug.Log(isOpen);
    }
}
