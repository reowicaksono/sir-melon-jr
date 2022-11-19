using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour
{

    [SerializeField] 
    public GameObject noteUI;
    public GameObject textUi;
    
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            
            
            // textUi.SetActive(true);
            // if(Input.GetKeyDown(KeyCode.E)) {
            //     _noteUI.enabled = true;
            //     textUi.SetActive(false);
            // }
            textUi.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            noteUI.SetActive(false);
            textUi.SetActive(false);
        }
    }
    private void Update() {
   
    }
}
