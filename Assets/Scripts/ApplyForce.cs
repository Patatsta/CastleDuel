using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;
    public float upForce;
    public float forwardForce;
    public float torqueForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, forwardForce, upForce), ForceMode.Impulse);
        rb.AddRelativeTorque(Vector3.right * torqueForce, ForceMode.Force);

    }
}

   
