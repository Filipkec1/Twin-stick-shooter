using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject LevelSelect;

    public int number;

    void Start()
    {

        MainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }

    public void PlayButton()
    {
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
    }

    public void BackToMainMenuButton()
    {
        MainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }
}
