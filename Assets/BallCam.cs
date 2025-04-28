using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCam : MonoBehaviour
{
    public Transform cannonball;   
    public Vector3 offset;         
    private Quaternion initialRotation;


    void LateUpdate()
    {
        if (cannonball != null)
        {
          
            transform.position = cannonball.position - cannonball.GetComponent<Rigidbody>().velocity.normalized * offset.z + Vector3.up * offset.y;

         
            transform.rotation = Quaternion.LookRotation(cannonball.GetComponent<Rigidbody>().velocity);
        }
    }
}
