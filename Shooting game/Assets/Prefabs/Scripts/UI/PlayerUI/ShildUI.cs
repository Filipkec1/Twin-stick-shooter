using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShildUI : MonoBehaviour
{
    public GameManagerController GMC;
    Text _shildhText;

    void Awake()
    {
        _shildhText = GetComponent<Text>();
    }

    void Update()
    {
        _shildhText.text = "Shild: " + GMC.PlayerObject.GetComponent<Target>().CurrentShield.ToString("0") + " / " + GMC.PlayerObject.GetComponent<Target>().MaxShield;
    }
}
