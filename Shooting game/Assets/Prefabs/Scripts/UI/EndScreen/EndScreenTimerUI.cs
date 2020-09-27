using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenTimerUI : MonoBehaviour
{
    Text _timeNeededToEnd;

    void Start()
    {

        _timeNeededToEnd = GetComponent<Text>();
        _timeNeededToEnd.text = "Time elapsed: " + GameManagerController.TimeSinceLevelStart;
    }
}
