using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public GameManagerController GMC;
    Text _enemyCountText;

    void Awake()
    {
        _enemyCountText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        _enemyCountText.text = "Enemies remaining: " + GMC.AliveEnemis + " / " + GMC.GameSetupController.EnemyCount;
    }
}
