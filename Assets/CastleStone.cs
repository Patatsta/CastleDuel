using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleStone : MonoBehaviour
{
    public int ID;
    private bool _isTriggered = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor") && !_isTriggered)
        {
           
            _isTriggered = true;
            GameManager.OnHitFloor?.Invoke(ID);
        }
    }
}
