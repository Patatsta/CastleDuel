using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonSimulated : MonoBehaviour
{
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private int _maxInteractions = 30;
    [SerializeField] private float simulationStep = 0.05f;

    private List<GameObject> _points = new List<GameObject>();

    private void Start()
    {
        ClearPoints();
    }

    public void SimulatedTrajectory(Cannonball ball, Vector3 pos, Vector3 velocity)
    {
        ClearPoints();

        var simulatedObj = Instantiate(ball, pos, Quaternion.identity);
        simulatedObj.GetComponent<Renderer>().enabled = false;

        Rigidbody rb = simulatedObj.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = true;

        SceneManager.MoveGameObjectToScene(simulatedObj.gameObject, SceneCreator.Instance._simulatedScene);

        simulatedObj.Init(0);
        simulatedObj.CannonShot(velocity, 1);

        for (int i = 0; i < _maxInteractions; i++)
        {
            SceneCreator.Instance._physicsScene.Simulate(simulationStep);
            GameObject point = Instantiate(pointPrefab, simulatedObj.transform.position, Quaternion.identity, transform);
            _points.Add(point);
        }

        Destroy(simulatedObj.gameObject);
    }

    public void SimulatedEnd()
    {
        ClearPoints();
    }

    private void ClearPoints()
    {
        foreach (var point in _points)
        {
            if (point != null)
                Destroy(point);
        }
        _points.Clear();
    }
}

