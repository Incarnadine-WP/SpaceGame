using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    public ParticleSystem playerDestroyed;

    private GameManager _gameManager;
    private PauseMenu _pauseMenu;

    private Vector3 _move;
    private float _time = 0f;

    private void Start()
    {
        _pauseMenu = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _move.z = Input.GetAxis("Vertical");
        _move.x = Input.GetAxis("Horizontal");

        DelayOfDamage();
    }

    private void FixedUpdate()
    {
        transform.Translate(_move * _speed * Time.deltaTime);
    }

    // interaction with enemy bullets
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (_time <= 0)
            {
                Debug.Log(collision.gameObject.name);
                _gameManager.UpdateLives();
                Destroy(collision.gameObject);
                _time = 1f;
            }

            if (_gameManager.currentLives <= 0)
            {
                Destroy(gameObject);
                Instantiate(playerDestroyed, transform.position, playerDestroyed.transform.rotation);
                _pauseMenu.GameOver();
            }
        }
    }

    private void DelayOfDamage()
    {
        if (_time > 0f)
        {
            _time -= Time.deltaTime;
        }
    }
}
