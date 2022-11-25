using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRiffle : MonoBehaviour
{
    public Camera cam;
    public float damage = 10f;
    public float range = 5f;
    public Animator Anim;
    public GameObject effectPunch;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        // Debug.Log(direction.magnitude);

        if (Input.GetButtonDown("Fire1") )
        {
            Shoot();
            Anim.SetBool("isPunch", true);
            // Debug.Log(Anim.GetFloat("speed"));
        }
        else
        {
            Anim.SetBool("isPunch", false);
        }
    }

    private void Shoot()
    {


        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            TargetHit target = hit.collider.GetComponent<TargetHit>();
            // Debug.Log(target);

            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject targetObject = Instantiate(effectPunch, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(targetObject, 1f);
            }
        }
    }
}
