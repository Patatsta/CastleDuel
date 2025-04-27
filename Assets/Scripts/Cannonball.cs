using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private Rigidbody rb;
  
    public void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

      
    public void CannonShot(Vector3 force)
    {
        if (rb == null) Init();
        rb.AddForce(force, ForceMode.Impulse);
    }
}
