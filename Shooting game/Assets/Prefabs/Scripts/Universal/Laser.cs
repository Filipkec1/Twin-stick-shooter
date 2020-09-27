using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject HitEffect;

    public LayerMask ShootingMask;
    public LayerMask LaserMask;
    public GameObject ShootingObject;

    public AudioSource AudioSourceCollision;

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSourceCollision.Play();
        Target target = collision.transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(ShootingObject.GetComponent<Shooting>().Damage);
        }

        GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
       
        Destroy(effect,0.05f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject,0.05f);
    }
}
