using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputSettings : MonoBehaviour
{
    private string inputLocal;
    public GameObject TextField;
    public GameObject slider;
    private Slider _sliderValue;
    private GameObject obj;

    private TMP_Text text;

    private void Start()
    {
        _sliderValue = slider.GetComponent<Slider>();
    }

    public void GrabFromInput(string input)
    {
        inputLocal = input;
        //DisplayInput();
    }

    private void DisplayInput()
    {
        TextField.GetComponent<TMP_Text>().text = "" + text;
    }
}
