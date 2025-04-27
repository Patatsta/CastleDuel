using UnityEngine;

public class AirMailPackage : MonoBehaviour
{
    private Rigidbody rb;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shot(Vector3 velocity)
    {
        if (rb == null) Init();
        rb.AddForce(velocity, ForceMode.Impulse);
    }
}

