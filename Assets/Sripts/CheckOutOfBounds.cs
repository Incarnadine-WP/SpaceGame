using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    private float _yBound = -19;

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
    }
}
