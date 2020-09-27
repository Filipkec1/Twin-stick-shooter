using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    //Spawn points
    public Transform[] PlayerSpawnPoints;
    public Transform[] EnemySpawnPoints;
    public Transform[] CrateSpawnPoints;
    public Transform[] ShiledPowerUpSpawnPoints;
    public Transform[] HealthPowerUpSpawnPoints;

    //Entities
    public GameObject PlayerObject;
    public GameObject EnemyObject;
    public GameObject CrateObject;

    //Power ups
    public GameObject ShiledPowerUpGameObject;
    public GameObject HealthPowerUpGameObject;

    //Counts
    public int EnemyCount;
    public int CrateCount;
    public int PowerUpCount;
    int _minPowerUpCount = 0;

    //Timers
    public float PowerUpTimer;

    //Camera
    public Camera PlayerCamera;


    void Start()
    {

        InstancePlayer();
        InstanceEnemies();
        InstanceCrates();
        InstanceShiledPowerUp();
        InstanceHealthPowerUps();
    }

    //Instance the player.
    void InstancePlayer()
    {
        int playerSpawnPicker = Random.Range(0, PlayerSpawnPoints.Length);

        GameObject player = Instantiate(PlayerObject, PlayerSpawnPoints[playerSpawnPicker].position, PlayerSpawnPoints[playerSpawnPicker].rotation);
        Camera cam = Instantiate(PlayerCamera, PlayerSpawnPoints[playerSpawnPicker].position, PlayerSpawnPoints[playerSpawnPicker].rotation);
        cam.GetComponent<FollowPlayer>().PlayerTarget = player.transform;
        player.GetComponent<PlayerMovment>().Cam = cam;
        cam.gameObject.SetActive(true);
    }

    //Instantiate the enemies.
    void InstanceEnemies()
    {
        int enemySpawnPicker;
        List<int> takenPlaces = new List<int>();

        for (int i = 0; i < EnemyCount; i++)
        {
            enemySpawnPicker = Random.Range(0, EnemySpawnPoints.Length);

            while (takenPlaces.Contains(enemySpawnPicker))
            {
                enemySpawnPicker = Random.Range(0, EnemySpawnPoints.Length);
            }

            takenPlaces.Add(enemySpawnPicker);

            GameObject enemy = Instantiate(EnemyObject, EnemySpawnPoints[enemySpawnPicker].position, EnemySpawnPoints[enemySpawnPicker].rotation);
        }
    }

    //Instantiate the crates.
    void InstanceCrates()
    {
        int crateSpawnPicker;
        List<int> takenPlaces = new List<int>();

        for (int i = 0; i < CrateCount; i++)
        {
            crateSpawnPicker = Random.Range(0, CrateSpawnPoints.Length);

            while (takenPlaces.Contains(crateSpawnPicker))
            {
                crateSpawnPicker = Random.Range(0, CrateSpawnPoints.Length);
            }

            takenPlaces.Add(crateSpawnPicker);

            GameObject crate = Instantiate(CrateObject, CrateSpawnPoints[crateSpawnPicker].position, CrateSpawnPoints[crateSpawnPicker].rotation);
        }
    }

    //Instantiate the shiled power ups.
    void InstanceShiledPowerUp()
    {

        GameObject[] shiledPowerUpExisting = GameObject.FindGameObjectsWithTag(ShiledPowerUpGameObject.tag);

        if(shiledPowerUpExisting.Length != PowerUpCount)
        {
            GameObject player = GameObject.FindGameObjectWithTag(PlayerObject.tag);

            for (int i = 0; i < PowerUpCount; i++)
            {

                if (shiledPowerUpExisting.Length == _minPowerUpCount)
                {
                    GameObject shiledPowerUp = Instantiate(ShiledPowerUpGameObject, ShiledPowerUpSpawnPoints[i].position, ShiledPowerUpSpawnPoints[i].rotation);
                    shiledPowerUp.GetComponent<PowerUp>().PlayerObject = player;
                }


                for(int j = 0; j < shiledPowerUpExisting.Length; j++)
                {
                    if(!(shiledPowerUpExisting[j].gameObject.transform.position == ShiledPowerUpSpawnPoints[i].position))
                    {
                        GameObject shiledPowerUp = Instantiate(ShiledPowerUpGameObject, ShiledPowerUpSpawnPoints[i].position, ShiledPowerUpSpawnPoints[i].rotation);
                        shiledPowerUp.GetComponent<PowerUp>().PlayerObject = player;
                    }
                }
            }
        }

        StartCoroutine("RespawnShiledPowerUp");
    }

    IEnumerator RespawnShiledPowerUp()
    {
        yield return new WaitForSeconds(PowerUpTimer);
        InstanceShiledPowerUp();
    }

    //Instantiate the health power ups.
    void InstanceHealthPowerUps()
    {
        GameObject[] healthPowerUpExisting = GameObject.FindGameObjectsWithTag(HealthPowerUpGameObject.tag);

        if (healthPowerUpExisting.Length != PowerUpCount)
        {
            GameObject player = GameObject.FindGameObjectWithTag(PlayerObject.tag);

            for (int i = 0; i < PowerUpCount; i++)
            {

                if (healthPowerUpExisting.Length == _minPowerUpCount)
                {
                    GameObject healthPowerUp = Instantiate(HealthPowerUpGameObject, HealthPowerUpSpawnPoints[i].position, HealthPowerUpSpawnPoints[i].rotation);
                    healthPowerUp.GetComponent<PowerUp>().PlayerObject = player;
                }


                for (int j = 0; j < healthPowerUpExisting.Length; j++)
                {
                    if (!(healthPowerUpExisting[j].gameObject.transform.position == HealthPowerUpSpawnPoints[i].position))
                    {
                        GameObject healthPowerUp = Instantiate(HealthPowerUpGameObject, HealthPowerUpSpawnPoints[i].position, HealthPowerUpSpawnPoints[i].rotation);
                        healthPowerUp.GetComponent<PowerUp>().PlayerObject = player;
                    }
                }
            }
        }

        StartCoroutine("RespawnHealthPowerUp");
    }


    IEnumerator RespawnHealthPowerUp()
    {
        yield return new WaitForSeconds(PowerUpTimer);
        InstanceHealthPowerUps();
    }
}
