using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    private GameManager _gameManager;
    private PauseMenu _pauseMenu;


    private float _yOtherBound = -19f;
    private float _xBound = 7.5f;
    private float _yMinPlayerBounds = -14;
    private float _yMaxPlayerBounds = -10;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _pauseMenu = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
    }

    private void Update()
    {
        BoundsCheck();
    }

    // deactivate/destroy item if it leaves the screen
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
            else if (transform.position.x < -_xBound)
            {
                transform.position = new Vector3(-_xBound, transform.position.y, transform.position.z);
            }
            else if (transform.position.y < _yMinPlayerBounds)
            {
                transform.position = new Vector3(transform.position.x, _yMinPlayerBounds, transform.position.z);
            }
            else if (transform.position.y > _yMaxPlayerBounds)
            {
                transform.position = new Vector3(transform.position.x, _yMaxPlayerBounds, transform.position.z);
            }
        }
    }

    private void PlayerBulletBoundsCheck()
    {
        if (gameObject.CompareTag("Bullet"))
        {
            if (transform.position.y <= _yOtherBound || transform.position.y >= 0)
                gameObject.SetActive(false);
        }
    }

    private void EnemyBulletBoundsCheck()
    {
        if (gameObject.CompareTag("EnemyBullet"))
        {
            if (transform.position.y <= _yOtherBound || transform.position.y >= 0)
                Destroy(gameObject);
        }
    }

    private void AsteroidsBoundsCheck()
    {
        if (gameObject.CompareTag("Asteroid"))
        {
            if (transform.position.y <= _yOtherBound)
            {
                Destroy(gameObject);
                _gameManager.UpdateLives();
                if(_gameManager.currentLives <= 0)
                {
                    _pauseMenu.GameOver();
                }
            }
        }
    }
}
