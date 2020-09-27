using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    public GameManagerController GMC;
    Text _gunText;

    void Awake()
    {
        _gunText = GetComponent<Text>();
    }

    void Update()
    {
        _gunText.text = "Gun: " + GMC.PlayerObject.GetComponent<Shooting>().CurrentAmmo + " / " + GMC.PlayerObject.GetComponent<Shooting>().MaxAmmo;
    }
}
