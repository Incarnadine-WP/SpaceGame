using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator[] _animator;
    public Image[] _hearts;

    public TextMeshProUGUI scoreText;

    public int currentLives = 3;

    private int score;


    public void UpdateLives()
    {
        if (currentLives == 3)
        {
            currentLives--;
            _animator[2].SetTrigger("DMG");
            _animator[3].SetTrigger("TakeDmg");
            Destroy(_hearts[2], 1f);
        }
        else if (currentLives == 2)
        {
            currentLives--;
            _animator[1].SetTrigger("DMG");
            _animator[3].SetTrigger("TakeDmg");
            Destroy(_hearts[1], 1f);
        }
        else if (currentLives == 1)
        {
            currentLives--;
            _animator[0].SetTrigger("DMG");
            _animator[3].SetTrigger("TakeDmg");
            Destroy(_hearts[0], 1f);
        }
    }

    public void UpdateScore(int amount)
    {
        score = amount;
        scoreText.text = "Score: " + score;
    }



}
