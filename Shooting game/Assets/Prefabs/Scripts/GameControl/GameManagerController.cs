using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{

    public GameSetupController GameSetupController;

    public GameObject PlayerObject;
    public int AliveEnemis;

    static public string TimeSinceLevelStart;

    int _minEnemys = 0;
    public bool AreAllEnemisDead = false;

    public AudioSource AudioSourceWin;
    public AudioSource AudioSourceLose;
    public AudioSource AudioSourceStart;

    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag(GameSetupController.PlayerObject.tag);
        AliveEnemis = GameObject.FindGameObjectsWithTag(GameSetupController.EnemyObject.tag).Length;

        TimeSinceLevelStart = System.TimeSpan.FromSeconds((int)Time.timeSinceLevelLoad).ToString();

        AudioSourceStart.Play();
    }

    void Update()
    {
        TimeSinceLevelStart = System.TimeSpan.FromSeconds((int)Time.timeSinceLevelLoad).ToString();
    }

    void FixedUpdate()
    {
        FindPlayer();
        FindEnemis();
    }

    void FindPlayer()
    {
        PlayerObject = GameObject.FindGameObjectWithTag(GameSetupController.PlayerObject.tag);
        bool playerAlive = PlayerObject;

        if(!playerAlive)
        {
            AudioSourceLose.Play();
        }
    }

    void FindEnemis()
    {
        AliveEnemis = GameObject.FindGameObjectsWithTag(GameSetupController.EnemyObject.tag).Length;

        if(AliveEnemis <= _minEnemys)
        {
            AreAllEnemisDead = true;
            AudioSourceWin.Play();
        }
    }
}
