using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private EnemyHpBar _enemyHPBar;
    [SerializeField] private ParticleSystem _explosionEnemyShip;

    private Transform[] _wayPoints;

    private float _speed = 5f;
    private int _currentPoint;
    private int _enemyMaxHP = 100;
    private int _currentEnemyHP;


    // Start is called before the first frame update
    private void Start()
    {
        EnemyHP();
        PointsToPatrol();
    }

    // Update is called once per frame
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
            collision.gameObject.SetActive(false);
            if(_currentEnemyHP <= 0)
            {
                Instantiate(_explosionEnemyShip, transform.position, _explosionEnemyShip.transform.rotation);
                Debug.Log("EnemyShip Destroyed!\nYou Win.");
                Destroy(gameObject);
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
