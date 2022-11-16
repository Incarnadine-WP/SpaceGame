using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] private float _speed;

    public ParticleSystem _playerDestroyed;

    private Vector3 _move;

    // Update is called once per frame
    void Update()
    {
        _move.x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Translate(_move * _speed * Time.deltaTime);
    }
  
}
