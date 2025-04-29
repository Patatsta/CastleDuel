using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}
