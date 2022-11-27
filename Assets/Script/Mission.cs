using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public Text mission1;
  

    public static Mission objek;
    // Start is called before the first frame update
    private void Awake()
    {
        objek = this;
    }

    public void getDataMission(bool data1, bool data2)
    {
        if (data1 == true)
        {
            mission1.text = "Completed";
            mission1.color = Color.green;
        }
        else
        {
            mission1.text = "01. Find Item";
            mission1.color = Color.white;
        }

       

    }

}
