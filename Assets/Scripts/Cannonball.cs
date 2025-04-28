using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject _explosion;

    [SerializeField] private List<Material> _materials;
    private Renderer _renderer;

    
    private enum _ballType
    {
        Normal,
        Explosive,
        Increase,
    }

    private _ballType _ball;

    public void Init()
    {
        _renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        int random = Random.Range(0,3);
     
        if (random == 0)
        {
            _renderer.material = _materials[random];
            _ball = _ballType.Normal;
        }
        else if (random == 1)
        {
            _renderer.material = _materials[random];
            _ball = _ballType.Increase;
        }
        else if (random == 2)
        {
            _renderer.material = _materials[random];
            _ball = _ballType.Explosive;
        }

    }

      
    public void CannonShot(Vector3 force)
    {
        if (rb == null) Init();
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ball == _ballType.Explosive)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<CastleStone>() != null)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Vector3 direction = (collider.transform.position - transform.position).normalized;
                        float force = 10f;
                        rb.AddForce(direction * force, ForceMode.Impulse);
                    }
                }

            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_ball == _ballType.Increase && transform.localScale.x <= 3f)
        {
            transform.localScale += Vector3.one * 2f * Time.deltaTime;
        }

    }
}
