using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int movementSpeed;
    private Vector2 currentRotation;
    public Animator Anim;
    float turnSpeed = 1;
    [SerializeField] bool isWalking = false;

    void Update()
    {
        isWalking = true;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = false;
        }
        MovingRelativeToCamera();
        
        Quaternion currentRot = transform.rotation;

        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion targetCameraRotation = new Quaternion(0, cameraRotation.y, cameraRotation.z, cameraRotation.z);
    }

    void RotasiPosisi(Vector3 moveDir)
    {
        if (moveDir != Vector3.zero)
        {
            Quaternion rotationTarget = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, movementSpeed * Time.deltaTime);
        }
    }


    void MovingRelativeToCamera()
    {
        float playerVerInput = Input.GetAxis("Vertical");
        float playerHorInput = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Debug.Log(forward);
        Vector3 forwardRelativeVerticalInput = new Vector3(forward.x, 0, forward.z) * playerVerInput;
        Vector3 rightRelativeVerticalInput = right * playerHorInput;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        turnSpeed = isWalking ? 0.5f : 1;
        transform.Translate(cameraRelativeMovement * movementSpeed * Time.deltaTime * turnSpeed, Space.World);
        Anim.SetFloat("speed", cameraRelativeMovement.magnitude * movementSpeed + .5f);


        Vector3 movement = new Vector3(playerHorInput, 0, playerVerInput) * Time.deltaTime * movementSpeed;
        Vector3 normalizeMovement = cameraRelativeMovement;

        RotasiPosisi(normalizeMovement);
    }
}
