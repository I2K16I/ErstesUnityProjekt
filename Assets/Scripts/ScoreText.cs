using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private GameManager _gameManager;
    
    private Text _textComp;
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _textComp = GetComponent<Text>();
        _textComp.text = _gameManager.score.ToString();
        _gameManager.scoreChanged.AddListener(UpdateScore);
    }
    
    public void UpdateScore()
    {
        _textComp.text = _gameManager.score.ToString();
    }
}
