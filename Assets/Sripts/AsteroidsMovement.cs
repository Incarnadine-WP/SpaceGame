using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _enemyRB;

    private float _maxTorque = 10f;

    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        _enemyRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            print("Game Over");
        }
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
}
