using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody _enemyRB;

    private float _maxSpeed = 7f;
    private float _minSpeed = 1f;
    private float _maxTorque = 10f;

    
    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        AsteroidsMove();
        EnemyTorque();
    }

    // private void Update() => AsteroidsMove();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            print("Game Over");
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
            print("Asteroid destroyed!");
        }
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    // adding rotation of asteroids
    private void EnemyTorque()
    {
        _enemyRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.VelocityChange);
    }

    private Vector3 RandomSpeed()
    {
        return Vector3.down * Random.Range(_minSpeed, _maxSpeed);
    }

    // adding moving of asteroids
    private void AsteroidsMove()
    {
        _enemyRB.AddForce(RandomSpeed(), ForceMode.Impulse);
    }
    
}
