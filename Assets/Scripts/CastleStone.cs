using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleStone : MonoBehaviour
{
    public int ID;
    private bool _isTriggered = false;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
      
       
    }
    private void Start()
    {
        DestructionManager.Instance.RegisterStone(_rb);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor") && !_isTriggered)
        {
            _isTriggered = true;
            GameManager.OnHitFloor?.Invoke(ID);
        }
    }
}
