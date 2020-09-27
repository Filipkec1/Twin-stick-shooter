using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePoused = false;

    public GameObject playerUI;
    public GameObject pauseMenuUI;

    public GameObject VictoryScreen;
    public GameObject LoseScreen;

    public GameManagerController GMC;

    string _mainMenu = "MainMenu";

    void Start()
    {
        playerUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        VictoryScreen.SetActive(false);
        LoseScreen.SetActive(false);

        Time.timeScale = 1f;
        IsGamePoused = false;
    }

    void Update()
    {
        if (IsGamePoused)
        {
            return;
        }

        if(GMC.PlayerObject == null)
        {
            ToLoseScreen();
        }

        if (GMC.AreAllEnemisDead)
        {
            ToVictoryScreen();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (IsGamePoused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;

        IsGamePoused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;


        IsGamePoused = true;
    }

    public void ToVictoryScreen()
    {

        pauseMenuUI.SetActive(false);
        playerUI.SetActive(false);
        VictoryScreen.SetActive(true);
        LoseScreen.SetActive(false);

        Time.timeScale = 0f;
        IsGamePoused = true;
    }

    public void ToLoseScreen()
    {

        pauseMenuUI.SetActive(false);
        playerUI.SetActive(false);
        VictoryScreen.SetActive(false);
        LoseScreen.SetActive(true);

        Time.timeScale = 0f;
        IsGamePoused = true;
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UnlockNextLevel()
    {
        LevelControlScript.Instance.YouWin();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }
}
