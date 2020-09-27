using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounterUI : MonoBehaviour
{

    Text _timerText;

    void Start()
    {
        _timerText = GetComponent<Text>();
    }

    void Update()
    {
        _timerText.text = GameManagerController.TimeSinceLevelStart;
    }
}
