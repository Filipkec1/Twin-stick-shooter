using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUI : MonoBehaviour
{
    public GameManagerController GMC;

    Text _enemyCount;

    void Start()
    {
        _enemyCount = GetComponent<Text>();
        _enemyCount.text = "Enemies destroy: " + (GMC.GameSetupController.EnemyCount - GMC.AliveEnemis) + " / " + GMC.GameSetupController.EnemyCount;
    }
}
