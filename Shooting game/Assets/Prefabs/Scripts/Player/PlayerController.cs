using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Shooting Shooting;

    void Update()
    {
        if (PauseMenu.IsGamePoused)
        {
            return;
        }

        //The player shoots.
        if (Input.GetButton("Fire1"))
        {
            Shooting.Shoot();
        }


        //The player reloads the gun.
        if (Input.GetButtonDown("Reload"))
        {
            Shooting.ReloadTriger();
        }
    }
}
