using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatedPhysics : MonoBehaviour
{
    //    private Scene _simulatedScene;
    //    private PhysicsScene _physicsScene;

    //    [SerializeField] private Transform labParent;
    //    [SerializeField] private LineRenderer _line;
    //    [SerializeField] private int _maxInteractions = 30;
    //    [SerializeField] private float simulationStep = 0.05f;

    //    private void Start()
    //    {
    //        if (labParent == null)
    //            labParent = transform.root;

    //        CreateSimulatedScene();
    //    }

    //    private void CreateSimulatedScene()
    //    {
    //        var parameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
    //        _simulatedScene = SceneManager.CreateScene("SimulatedPhysics", parameters);
    //        _physicsScene = _simulatedScene.GetPhysicsScene();

    //        foreach (Transform obstacle in labParent)
    //        {
    //            if (obstacle.CompareTag("Obstacle"))
    //            {
    //                GameObject copy = Instantiate(obstacle.gameObject, obstacle.position, obstacle.rotation);

    //                if (copy.TryGetComponent<Renderer>(out var rend))
    //                    rend.enabled = false;

    //                SceneManager.MoveGameObjectToScene(copy, _simulatedScene);
    //            }
    //        }
    //    }

    //    public void SimulatedTrajectory(AirMailPackage air, Vector3 pos, Vector3 velocity)
    //    {
    //        var simulatedObj = Instantiate(air, pos, Quaternion.identity);
    //        simulatedObj.GetComponent<Renderer>().enabled = false;

    //        Rigidbody rb = simulatedObj.GetComponent<Rigidbody>();
    //        rb.velocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //        rb.useGravity = true;

    //        SceneManager.MoveGameObjectToScene(simulatedObj.gameObject, _simulatedScene);

    //        simulatedObj.Init(); 
    //        simulatedObj.Shot(velocity);

    //        _line.positionCount = _maxInteractions;

    //        for (int i = 0; i < _maxInteractions; i++)
    //        {
    //            _physicsScene.Simulate(simulationStep);
    //            _line.SetPosition(i, simulatedObj.transform.position);
    //        }

    //        Destroy(simulatedObj.gameObject);
    //    }
}

