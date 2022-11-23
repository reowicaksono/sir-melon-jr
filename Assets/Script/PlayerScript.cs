using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    PlayerController controller;
    public int movementSpeed;
    public Animator Anim;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    float turnSpeed = 1;
    [SerializeField] bool isWalking = false;
    [SerializeField] Rigidbody rb;
    public Transform cam;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        controller = new PlayerController();
        controller.Enable();

    }

    void FixedUpdate()
    {
        Vector2 move = controller.Land.Newaction.ReadValue<Vector2>();
        isWalking = true;
        playerMove();


    }

    void playerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);
             transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if(Input.GetKey(KeyCode.LeftShift)) isWalking = false;
            turnSpeed = isWalking ? 0.1f : 1f; 

            Vector3 moveDirection = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward * turnSpeed;
            Anim.SetFloat("speed", turnSpeed);

            Vector3 data = rb.velocity = moveDirection.normalized * movementSpeed * Time.deltaTime;
            rb.AddForce(data, ForceMode.VelocityChange);
        }
        else{
            Anim.SetFloat("speed", direction.magnitude);
        }
    }

}