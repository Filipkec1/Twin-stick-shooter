using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameManagerController GMC;
    Text _healthText;

    void Awake()
    {
        _healthText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (GMC.PlayerObject == null)
        {
            return;
        }

        _healthText.text = "Health: " + GMC.PlayerObject.GetComponent<Target>().CurrentHealth.ToString("0") + " / " + GMC.PlayerObject.GetComponent<Target>().MaxHealth;
    }
}
