using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerController controller;
    public int movementSpeed;
    private Vector2 currentRotation;
    public Animator Anim;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    float turnSpeed = 1;
    [SerializeField] bool isWalking = false;
    [SerializeField] Rigidbody rb;
    public Transform cam;
    void Start()
    {
        Cursor.visible = false;
    }

    void Awake()
    {
        controller = new PlayerController();
        controller.Enable();

    }

    void FixedUpdate()
    {
        Vector2 move = controller.Land.Newaction.ReadValue<Vector2>();
        if (move.magnitude >= 0.1f)
        {
            Vector3 moveDir = new Vector3(move.x, 0, move.y).normalized;

            float tragetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveVelocity = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveVelocity.normalized * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }


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
            Anim.SetFloat("speed", cameraRelativeMovement.magnitude * movementSpeed + .5f);
            transform.Translate(cameraRelativeMovement * movementSpeed * Time.deltaTime * turnSpeed, Space.World);


            Vector3 movement = new Vector3(playerHorInput, 0, playerVerInput) * Time.deltaTime * movementSpeed;
            Vector3 normalizeMovement = cameraRelativeMovement;

            RotasiPosisi(normalizeMovement);
        
    }
}
