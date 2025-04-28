using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleStone : MonoBehaviour
{
    [SerializeField] private int _blockID;
    private bool _isTriggered = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor") && !_isTriggered)
        {
            _isTriggered = true;
            GameManager.OnHitFloor?.Invoke(_blockID);
        }
    }
}
