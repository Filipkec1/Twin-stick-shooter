using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{

    public Button LevelTwoButton;
    public Button LevelThreeButton;

    int _levelPassed;

    void Start()
    {
        _levelPassed = PlayerPrefs.GetInt("LevelPassed");

        LevelTwoButton.interactable = false;
        LevelThreeButton.interactable = false;

        switch (_levelPassed)
        {
            case 1:
                LevelTwoButton.interactable = true;
                break;
            case 2:
                LevelTwoButton.interactable = true;
                LevelThreeButton.interactable = true;
                break;
        }
    }

    public void LevelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }
}
