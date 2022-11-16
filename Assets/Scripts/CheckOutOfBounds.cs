using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    private float _yBound = -19f;
    private float _xBound = 9f;

    private void Update()
    {
        BoundsCheck();
    }

    // deactivate item if it leaves the screen
    private void BoundsCheck()
    {
        PlayerBoundsCheck();
        PlayerBulletBoundsCheck();
        EnemyBulletBoundsCheck();
        AsteroidsBoundsCheck();
    }

    private void PlayerBoundsCheck()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (transform.position.x > _xBound)
            {
                transform.position = new Vector3(_xBound, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -_xBound)
            {
                transform.position = new Vector3(-_xBound, transform.position.y, transform.position.z);
            }
        }
    }

    private void PlayerBulletBoundsCheck()
    {
        if (gameObject.CompareTag("Bullet"))
        {
            if (transform.position.y <= _yBound || transform.position.y >= 0)
                gameObject.SetActive(false);
        }
    }

    private void EnemyBulletBoundsCheck()
    {
        if (gameObject.CompareTag("EnemyBullet"))
        {
            if (transform.position.y <= _yBound || transform.position.y >= 0)
                Destroy(gameObject);
        }
    }

    private void AsteroidsBoundsCheck()
    {
        if (gameObject.CompareTag("Asteroid"))
        {
            if (transform.position.y <= _yBound)
                Destroy(gameObject);
        }
    }
}
