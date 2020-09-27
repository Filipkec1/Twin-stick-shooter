using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject PlayerObject;
    public Component PowerUpEffect;

    public AudioSource AudioSourceOnPickUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.gameObject.tag == PlayerObject.tag)
       {
            PowerUpEffect.gameObject.GetComponent<IPowerUpEffect>().Effect();

            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            AudioSourceOnPickUp.Play();
            Destroy(gameObject, 0.2f);
       }
    }


}
