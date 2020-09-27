using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour
{

    public static LevelControlScript Instance = null;

    int _sceneIndex;
    int _levelPassed;

    string _mainMenu = "MainMenu";

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    public void YouWin()
    {

        if (_sceneIndex == 3)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (_levelPassed < _sceneIndex)
            {
                PlayerPrefs.SetInt("LevelPassed", _sceneIndex);
            }

            Invoke("LoadNextLevel", 1f);
        }
    }

    public void youLose()
    {
        Invoke("LoadMainMenu", 1f);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(_sceneIndex + 1);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }
}
