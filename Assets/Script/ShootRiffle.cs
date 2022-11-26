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

        float data = Anim.GetFloat("speed");
        if (Input.GetButton("Fire1"))
        {
            Shoot();
            Anim.SetBool("isPunch", true);

            // float a = Time.time;
            // if(a > nextToTime){
            //     Anim.SetBool("isPunch2", true);
            //     nextToTime += Time.time/5;  
            // }else{
            //     Anim.SetBool("isPunch2", false);
            // }

            // Debug.Log(Anim.GetBool("isPunch2") + " =  " + a + " data time " + nextToTime);

        
        }
        else if (Input.GetButton("Fire1") && data == 0.1)
        {
            Shoot();
            Anim.SetBool("isPunch", true);
        }
        else if (Input.GetButton("Fire1") && Input.GetButton("Fire2"))
        {
            Shoot();
            Anim.SetBool("isPunch", true);
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