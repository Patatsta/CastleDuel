using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarardDetect : MonoBehaviour
{
    public float radius = 5f;
    public float power = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hazard"))
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if(rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Impulse);

            }
            Destroy(gameObject);
        }
    }
}
