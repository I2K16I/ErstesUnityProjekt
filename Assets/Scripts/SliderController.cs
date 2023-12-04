using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider _slider;
    private GameManager _gm;
    public GameObject textfield;

    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _slider = GetComponent<Slider>();
        _slider.value = _gm.mouseSens;
        _text = textfield.GetComponent<Text>();
        _slider.onValueChanged.AddListener(UpdateSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "" + _slider.value;
    }

    private void UpdateSensitivity(float newValue)
    {
        _gm.ChangeMouseSens(newValue);
    }
}
