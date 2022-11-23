using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRiffle : MonoBehaviour
{
    public Camera cam;
    public float damage = 10f;
    public float range = 100f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            TargetHit target = hit.collider.GetComponent<TargetHit>();
            Debug.Log(target);

            if (target != null)
            {
                target.TakeDamage(damage);
                Debug.Log("enemy");
            }
        }
    }
}
