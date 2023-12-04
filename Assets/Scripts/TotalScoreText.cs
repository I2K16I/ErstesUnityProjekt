using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager _gameManager;
    
    private Text _textComp;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _textComp = GetComponent<Text>();
        _textComp.text = _gameManager.totalScore.ToString() + " Punkte";
    }
}
