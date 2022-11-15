using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _repeatHeight;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    private void Start()
    {
        _startPosition = transform.position;
        _repeatHeight = GetComponent<BoxCollider>().size.y / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        SetPosition();
        MoveBackGround();
    }

    private void SetPosition()
    {
        if (transform.position.y < _startPosition.y - _repeatHeight)
        {
            transform.position = _startPosition;
        }
    }

    private void MoveBackGround()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
