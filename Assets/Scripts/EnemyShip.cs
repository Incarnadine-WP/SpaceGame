using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private EnemyHpBar _enemyHPBar;
    [SerializeField] private ParticleSystem _explosionEnemyShip;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _enemyShipDestroyedSound;

    private AudioSource _audio;
    private PauseMenu _pauseMenu;
    private Transform[] _wayPoints;
    private GameManager _gameManager;

    private float _speed = 5f;
    private int _currentPoint;
    private int _enemyMaxHP = 100;
    private int _currentEnemyHP;

    // Start is called before the first frame update
    private void Start()
    {
        _audio = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
        _pauseMenu = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        EnemyHP();
        PointsToPatrol();
    }

    private void Update()
    {
        MoveToPatrolPoints();
    }

    private void MoveToPatrolPoints()
    {
        Transform target = _wayPoints[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _wayPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void PointsToPatrol()
    {
        _wayPoints = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            _animator.Play("EnemyTakeDmg");

            collision.gameObject.SetActive(false);

            if (_currentEnemyHP <= 0)
            {
                Instantiate(_explosionEnemyShip, transform.position, _explosionEnemyShip.transform.rotation);
                Debug.Log("EnemyShip Destroyed!");
                _gameManager.UpdateScore(40);
                _gameManager.KilledEnemyShips(1);
                _audio.PlayOneShot(_enemyShipDestroyedSound, 1f);
                Destroy(gameObject);

                if (_gameManager.killedEnemy == 3)
                {
                    _pauseMenu.LevelComplete();
                }
            } 
        }
    }

    private void EnemyHP()
    {
        _currentEnemyHP = _enemyMaxHP;
        _enemyHPBar.SetMaxHp(_enemyMaxHP);
    }

    private void TakeDamage(int dmg)
    {
        _currentEnemyHP -= dmg;
        _enemyHPBar.SetHp(_currentEnemyHP);
    }
}
