using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRegion : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _wayPoints;

    private float _speed = 5f;
    private int _currentPoint;


    // Start is called before the first frame update
    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Transform target = _wayPoints[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;
            if(_currentPoint >= _wayPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
