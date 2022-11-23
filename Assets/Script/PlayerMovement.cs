using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        isWalking = true;
        if (move.magnitude >= 0.1f)
        {
            Vector3 moveDir = new Vector3(move.x, 0, move.y).normalized;

            float tragetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if (Input.GetKey(KeyCode.LeftShift)) isWalking = false;
            turnSpeed = isWalking ? 0.1f : 1f;
            Vector3 moveVelocity = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward * turnSpeed;
            Anim.SetFloat("speed", turnSpeed);
            // Debug.Log(Anim.GetFloat("speed"));

            Vector3 data = rb.velocity = moveVelocity.normalized * movementSpeed * Time.deltaTime;
            rb.AddForce(data, ForceMode.VelocityChange);

        }
        else
        {
            Anim.SetFloat("speed", move.magnitude);
        }


    }


}
