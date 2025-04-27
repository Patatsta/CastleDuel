using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Base Rotation")]
    public Transform baseTransform;
    public float baseRotationSpeed = 50f;
    public float baseMinRotation = -60f;
    public float baseMaxRotation = 60f;

    [Header("Barrel Rotation")]
    public Transform barrelTransform; 
    public float barrelRotationSpeed = 30f;
    public float barrelMinAngle = 0f;
    public float barrelMaxAngle = 45f;

    private float currentBaseRotation = 0f;
    private float currentBarrelRotation = 0f;

    [SerializeField] private Cannonball _ballPrefab;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _force;
    [SerializeField] private CannonSimulated _physics;
    [SerializeField] private bool _isForce = false;

    [SerializeField] private float _maxForce;
    [SerializeField] private float _minForce;
    [SerializeField] private float _chargeMultiplier;
    private void Start()
    {
        _force = 20f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _force = _minForce;
        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (_force <= _minForce)
            {
                _isForce = true;
            }
            else if (_force >= _maxForce)
            {
                _isForce = false;
            }
            if (_isForce)
            {
                _force += 50 * Time.deltaTime;
            }
            else
            {
                _force -= 50 * Time.deltaTime;
            }
        }
        

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Cannonball ball = Instantiate(_ballPrefab, _shotPoint.position, Quaternion.identity);
            ball.CannonShot(_shotPoint.forward * _force);
            _physics.SimulatedEnd();
        }

      
        float horizontalInput = Input.GetAxis("Horizontal");
        currentBaseRotation += horizontalInput * baseRotationSpeed * Time.deltaTime;
        currentBaseRotation = Mathf.Clamp(currentBaseRotation, baseMinRotation, baseMaxRotation);
        baseTransform.localRotation = Quaternion.Euler(0f, currentBaseRotation, 0f);

      
        float verticalInput = Input.GetAxis("Vertical");
        currentBarrelRotation -= verticalInput * barrelRotationSpeed * Time.deltaTime; 
        currentBarrelRotation = Mathf.Clamp(currentBarrelRotation, barrelMinAngle, barrelMaxAngle);
        barrelTransform.localRotation = Quaternion.Euler(currentBarrelRotation, 0f, 0f);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _physics.SimulatedTrajectory(_ballPrefab, _shotPoint.position, _shotPoint.forward * _force);
        }
    }
}


