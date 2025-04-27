using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonSimulated : MonoBehaviour
{
   


    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxInteractions = 30;
    [SerializeField] private float simulationStep = 0.05f;

    private void Start()
    {  
      
        _line.enabled = false;
    }



    public void SimulatedTrajectory(Cannonball ball, Vector3 pos, Vector3 velocity)
    {
        _line.enabled = true;
        var simulatedObj = Instantiate(ball, pos, Quaternion.identity);
        simulatedObj.GetComponent<Renderer>().enabled = false;

        Rigidbody rb = simulatedObj.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = true;

        SceneManager.MoveGameObjectToScene(simulatedObj.gameObject, SceneCreator.Instance._simulatedScene);

        simulatedObj.Init();
        simulatedObj.CannonShot(velocity);

        _line.positionCount = _maxInteractions;

        for (int i = 0; i < _maxInteractions; i++)
        {
            SceneCreator.Instance._physicsScene.Simulate(simulationStep);
            _line.SetPosition(i, simulatedObj.transform.position);
        }

        Destroy(simulatedObj.gameObject);
    }

    public void SimulatedEnd()
    {
        _line.enabled = false;
    }
}
