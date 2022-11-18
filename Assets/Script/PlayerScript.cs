using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    private float rotateSpeed = 40f;
    public Animator Anim;
    float turnSpeed = 1;



    bool isWalking = false;
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = true;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = false;
        }
        turnSpeed = isWalking ? 0.5f : 1;
        Vector3 movement = new Vector3(h, 0, v) * Time.deltaTime * speed * turnSpeed;

        Anim.SetFloat("speed", movement.magnitude * speed + .5f);
        transform.Translate(movement, Space.World);
        AnimasiLari(isWalking);

        Vector3 normalizeMovement = movement.normalized;

        RotasiPosisi(normalizeMovement);
        // RotasiPosisi(NormalizedMove);

        // if (Input.GetKey(KeyCode.LeftShift))
        // {

        //     isWwalking = false;
        // }


    }

    void RotasiPosisi(Vector3 moveDir)
    {
        if (moveDir != Vector3.zero)
        {
            Quaternion rotationTarget = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, speed * Time.deltaTime);
        }
    }

    void AnimasiLari(bool isWalking)
    {
        Anim.SetBool("isWalking", isWalking);
    }


}
