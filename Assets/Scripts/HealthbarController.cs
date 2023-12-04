using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    private Slider slider;
    private GameManager _gm;
    
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _gm.hpChanged.AddListener(SetHealthbar);
        slider.maxValue = _gm.maxHpCounter;
        slider.value = slider.maxValue;
    }
    
    private void SetHealthbar()
    {
        slider.maxValue = _gm.maxHpCounter;
        slider.value = _gm.currentHpCounter;
    }
}
