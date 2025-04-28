using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action<int> OnHitFloor;
    void Start()
    {
        OnHitFloor = AddPoints;
    }

    private void AddPoints(int id)
    {
        Debug.Log("AddPoints");
    }
}
