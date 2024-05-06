using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 100.0F;

    Timebody tb;

    private void Start()
    {
        tb = GetComponent<Timebody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && !tb.getPaused())
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddForce(forceAdded(rb.position));
            }

            gameObject.SetActive(false);
        }
    }

    Vector3 forceAdded(Vector3 pos)
    {
        return (pos - transform.position).normalized * power;
    }

}
