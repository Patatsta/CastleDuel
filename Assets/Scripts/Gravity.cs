using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _gravity;
    private ConstantForce _constantForce;
    private void Start()
    {
        _constantForce = GetComponent<ConstantForce>();
        //Physics.gravity = new Vector3 (0, _gravity, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _constantForce.force = new Vector3(0,_gravity,0);
        }
    }
}
