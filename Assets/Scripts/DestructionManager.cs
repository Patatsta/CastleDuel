using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionManager : MonoBehaviour
{
    public static DestructionManager Instance;

    private List<Rigidbody> _trackedStones = new List<Rigidbody>();
    private bool _checking = false;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterStone(Rigidbody stoneRb)
    {
        _trackedStones.Add(stoneRb);
    }

    public void StartChecking()
    {
        if (!_checking)
            StartCoroutine(CheckDestructionDone());
    }

    private IEnumerator CheckDestructionDone()
    {
        _checking = true;

        yield return new WaitForSeconds(2f); 

        while (true)
        {
           
            int sleeping = 0;

            foreach (var stone in _trackedStones)
            {
                if (stone == null) continue; 
                if (stone.IsSleeping())
                    sleeping++;
            }

            float sleepRatio = (float)sleeping / _trackedStones.Count;
            print(sleepRatio);
            if (sleepRatio >= 0.95f) 
            {
                CameraManager.Instance.ChangePlayer();
                break;
            }

            yield return new WaitForSeconds(0.5f); 
        }

        _checking = false;
    }
}
