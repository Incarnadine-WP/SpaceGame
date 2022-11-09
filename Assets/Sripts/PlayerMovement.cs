using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

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
