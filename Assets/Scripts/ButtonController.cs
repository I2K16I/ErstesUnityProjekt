using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private int _lastLevelBuildIndex = 5;
    public void startFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void startSecondLevel()
    {
        SceneManager.LoadScene(3);

    }
    public void startThirdLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < _lastLevelBuildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Einstellungen()
    {
        SceneManager.LoadScene(1);
    }

    public void Endscene()
    {
        SceneManager.LoadScene(5);
    }

    public void CloseSettings()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().OnMenu();
        }
    }

}
