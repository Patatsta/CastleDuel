using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCreator : MonoBehaviour
{
    private static SceneCreator _instance;
    public static SceneCreator Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("SceneCreator == NULL");

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public Scene _simulatedScene { get; private set; }


    public PhysicsScene _physicsScene { get; private set; }

    [SerializeField] private Transform _cannonParent;


    void Start()
    {
        if (_cannonParent == null)
            _cannonParent = transform.root;

        CreateSimulatedScene();
    }

    private void CreateSimulatedScene()
    {
        var parameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
        _simulatedScene = SceneManager.CreateScene("SimulatedPhysics", parameters);
        _physicsScene = _simulatedScene.GetPhysicsScene();

        foreach (Transform obstacle in _cannonParent)
        {
            if (obstacle.CompareTag("Obstacle"))
            {
                GameObject copy = Instantiate(obstacle.gameObject, obstacle.position, obstacle.rotation);

                if (copy.TryGetComponent<Renderer>(out var rend))
                    rend.enabled = false;

                SceneManager.MoveGameObjectToScene(copy, _simulatedScene);
            }
        }
    }
}
