using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static int _totalScore = 0; 
    private static float _mouseSens = 1f;
    
    private int _time;
    private int _maxHpCounter = 5;
    private int _currentHpCounter = 5;
    public int minScoreToWin = 5;
    private int _score = 0;
    private int _currentDoT = 0;
    private float _dotDelay = 0f;
    private Boolean _isTakingDoT = false;
    private Boolean _isDragging;
    private Vector3 lastSafePointOnGround = new Vector3(0, 0, 0);
    private Vector3 _externalForce = new Vector3(0, 0, 0);
    private GameObject looseScreen;
    private GameObject WinScreen;
    private GameObject Settings;
    private CursorLockMode tempCurrent;
    public float mouseSens { get { return _mouseSens; } }
    public int time { get { return _time; } }
    public int maxHpCounter { get { return _maxHpCounter; } }
    public int currentHpCounter { get { return _currentHpCounter; } }
    public int score { get { return _score; } }
    public int totalScore { get { return _totalScore; } }
    public Vector3 externalForce { get { return _externalForce; } }
    public Boolean isDragging { get { return _isDragging; } }
    
    public UnityEvent hpChanged = new UnityEvent();
    public UnityEvent scoreChanged = new UnityEvent();
    public UnityEvent timeChanged = new UnityEvent();
    public UnityEvent externalForceChanged = new UnityEvent();
    public UnityEvent mouseSensitivityChanged = new UnityEvent();

    public void Start()
    {
        looseScreen = GameObject.Find("Meldung Kugel Absturz");
        looseScreen.SetActive(false);
        WinScreen = GameObject.Find("Zwischenszene");
        WinScreen.SetActive(false);
        Settings = GameObject.Find("Settings");
        Settings.SetActive(false);
    }

    public void AddScore()
    {
        _score++;
        _totalScore++;
        scoreChanged.Invoke();
        Debug.Log("Aktueller Score: " + _score);
        // Bin mir noch nicht sicher ob dieser Befehl tatsächlich die Anzahl an Szenen im Build ausgibt
        // falls ja: die _lastLevelBuildIndex-Variable damit ersetzen
        //Debug.Log( "Anzahl der Szenen: " + SceneManager.sceneCountInBuildSettings);
    }

    public void CheckIfWon()
    {
        if (_score < minScoreToWin)
        {
            Debug.Log("Please collect at least " + minScoreToWin + " Coins(?) to unlock the goal :)");
            return;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        WinScreen.SetActive(true);
        /*if (SceneManager.GetActiveScene().buildIndex < _lastLevelBuildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }*/
    }

    public void OnMenu()
    {
        if (Time.timeScale == 1.0f)
        {
            tempCurrent = Cursor.lockState;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Settings.SetActive(true);
        }
        else
        {
            Settings.SetActive(false);
            Time.timeScale = 1.0f;
            if (tempCurrent == Cursor.lockState)
            {
                return;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ToggleDragingStatus()
    {
        _isDragging = !_isDragging;
    }
    public void takeDmg(int dmgTaken)
    {
        _currentHpCounter -= dmgTaken;
        hpChanged.Invoke();
        if (currentHpCounter <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LooseLevel();
        }
    }

    public void ActivateDoT(int dotDmg, float delta)
    {
        if (!_isTakingDoT)
        {
            _currentDoT = dotDmg;
            _dotDelay = delta;
            _isTakingDoT = true;
            Invoke("TakeDoT", 0.5f);
        }
    }

    public void DeactivateDot()
    {
        
        _isTakingDoT = false;
    }
    
    public void TakeDoT()
    {
        if (_isTakingDoT)
        {
            takeDmg(_currentDoT);
            Invoke("TakeDoT", _dotDelay);
        }
    }

    public void gainMaxHp()
    {
        _maxHpCounter++;
        _currentHpCounter = _maxHpCounter;
        hpChanged.Invoke();
    }

    public void LooseLevel()
    {
        looseScreen.SetActive(true);
    }

    public void FellOfMap()
    {
        takeDmg(1);
        if (currentHpCounter <= 0)
        {
            Debug.Log("He fell and is dead");
            LooseLevel();
        }
        else
        {
            Debug.Log("He fell and is not dead");
            GameObject.FindWithTag("Player").GetComponent<Transform>().position = lastSafePointOnGround;
        }
    }
    public void LeftSaveGround(Vector3 lastSafePoint)
    {
        lastSafePointOnGround = lastSafePoint;
    }

    public void AddExternalForceToPlayer(Vector3 force)
    {
        _externalForce = force;
        externalForceChanged.Invoke();
    }

    public void ChangeMouseSens(float newValue)
    {
        Debug.Log("Changed Sens to: " + newValue);
        _mouseSens = newValue;
        mouseSensitivityChanged.Invoke();
    }
}
