using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    [SerializeField] private List<WheelCollider> _wheelCols = new List<WheelCollider>();
 


    public void ApplyVisualTransform(WheelCollider collider)
    {
       
         Transform wheel = collider.transform.GetChild(0);

            Vector3 position;
         Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

         wheel.position = position;
         wheel.rotation = rotation;
    
      

       
    }
    private void FixedUpdate()
    {
        foreach(WheelCollider c in _wheelCols)
        {
            ApplyVisualTransform(c);
        }
       
       
    }
}
