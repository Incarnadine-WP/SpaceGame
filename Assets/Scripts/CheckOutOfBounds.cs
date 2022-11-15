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
        
        if(gameObject.CompareTag("Asteroid"))
        {
            if (transform.position.y <= _yBound)
                Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Bullet"))
        {
            if (transform.position.y <= _yBound || transform.position.y >= 0)
                gameObject.SetActive(false);
        }
        else if (gameObject.CompareTag("Player"))
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
}
