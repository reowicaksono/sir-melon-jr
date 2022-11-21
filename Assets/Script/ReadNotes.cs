using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour
{

    [SerializeField]
    GameObject noteUI;
    GameObject textUi;

    bool isRead = false;


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isRead)
            {
                noteUI.SetActive(false);
                textUi.SetActive(true);
            }
            else
            {
                noteUI.SetActive(true);
                textUi.SetActive(false);
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            noteUI.SetActive(false);
            textUi.SetActive(false);
        }
    }
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E)) isRead = true;
        isRead = Input.GetKey(KeyCode.E) ? isRead = true : isRead = false;
        Debug.Log(isRead);
    }
}
