using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator[] _animator;
    public Image[] _hearts;

    public int currentLives = 3;

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLives()
    {
        if (currentLives == 3)
        {
            currentLives--;
            _animator[2].SetTrigger("DMG");
            Destroy(_hearts[2], 1f);
        }
        else if(currentLives == 2)
        {
            currentLives--;
            _animator[1].SetTrigger("DMG");
            Destroy(_hearts[1], 1f);
        }
        else if (currentLives == 1)
        {
            currentLives--;
            _animator[0].SetTrigger("DMG");
            Destroy(_hearts[0], 1f);
        }
    }

}
