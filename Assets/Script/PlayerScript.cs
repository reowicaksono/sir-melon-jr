using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    private float rotateSpeed = 40f;
    public float h;
    public Animator Anim;
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
            Anim.SetFloat("Speed",speed);
        }
        else{
            Anim.SetFloat("Speed",speed);
        }
        transform.Rotate(Vector3.up*Time.deltaTime*h*rotateSpeed);
        
        
    }

}
