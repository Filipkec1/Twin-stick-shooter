using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject LaserObject;

    public float LaserForce = 20f;
    public float Damage = 10f;

    public float FireRate = 15f;
    float _nextTimeToFire = 0f;

    public int MaxAmmo = 10;
    public int CurrentAmmo;

    public float ReloadTime = 1f;
    bool _isReloading = false;

    public AudioSource AudioSourceFire;


    void Start()
    {
        CurrentAmmo = MaxAmmo;
    }


    //Does the shooting, determins the characteristics of a laser.
    public void Shoot()
    {

        if (PauseMenu.IsGamePoused)
        {
            return;
        }

        if (_isReloading)
        {
            return;
        }

        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Time.time >= _nextTimeToFire)
        {

            _nextTimeToFire = Time.time + 1f / FireRate;

            CurrentAmmo--;

            AudioSourceFire.Play();

            GameObject laser = Instantiate(LaserObject, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb =  laser.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * LaserForce, ForceMode2D.Impulse);
        }


    }

    //Check if a relaod is posible.
    public void ReloadTriger()
    {
        if (!(CurrentAmmo == MaxAmmo))
        {
            StartCoroutine(Reload());
        }
    }

    //Does the reloading.
    IEnumerator Reload()
    {
        _isReloading = true;

        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;
        _isReloading = false;
    }
}
