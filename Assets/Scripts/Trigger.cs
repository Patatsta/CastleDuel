using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = other.GetComponent<Renderer>();

        renderer.material.SetColor("_EmissionColor", Color.green * 10f);
    }
}
