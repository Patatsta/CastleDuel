using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    [SerializeField] private int newPlayerID = 2;

    void Start()
    {
        CastleStone[] stones = GetComponentsInChildren<CastleStone>();

        foreach (CastleStone stone in stones)
        {
            stone.ID = newPlayerID;
        }
    }
}
