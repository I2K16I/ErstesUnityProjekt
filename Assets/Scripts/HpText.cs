using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{
    private GameManager _gm;
    private Text _textComp;
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _textComp = GetComponent<Text>();
        _textComp.text = _gm.currentHpCounter + " / " + _gm.maxHpCounter;
        _gm.hpChanged.AddListener(UpdateHpCounter);
    }

    void UpdateHpCounter()
    {
        Debug.Log("current HP: " + _gm.currentHpCounter);
        
        _textComp.text = _gm.currentHpCounter + " / " + _gm.maxHpCounter;
    }
}
