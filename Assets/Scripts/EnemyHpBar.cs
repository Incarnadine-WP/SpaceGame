using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    public void SetMaxHp(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHp(int heatlh)
    {
        _slider.value = heatlh;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }


}
