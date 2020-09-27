using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float MaxHealth;

    public float CurrentHealth;

    public bool IsAlive = true;
    public bool HasShiled = false;

    public float MaxShield;
    float _minShield = 0;

    public float CurrentShield;

    public float ShieldRegenSpeed;
    public float ShieldRegenStart;

    public bool canRegenShield;

    public AudioSource AudioSourceDeath;

    public Behaviour[] _componentsToDisableDeath;

    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentShield = MaxShield;

        if(HasShiled == false)
        {
            canRegenShield = false;
        }
        else
        {
            canRegenShield = true;
        }
    }

    void Update()
    {

        if (HasShiled && CurrentShield < MaxShield && canRegenShield)
        {

            CurrentShield += ShieldRegenSpeed * Time.deltaTime;

            if(CurrentShield > MaxShield)
            {
                CurrentShield = MaxShield;
            }
        }
    }


    public void TakeDamage(float amount)
    {

        StopCoroutine("ShiledRegenCounter");
        canRegenShield = false;
        StartCoroutine("ShiledRegenCounter");

        if (!IsAlive)
        {
            return;
        }

        if (HasShiled && CurrentShield > 0f)
        {
            CurrentShield -= amount;

            if(CurrentShield < 0f)
            {
                CurrentHealth += CurrentShield;
                CurrentShield = _minShield;
            }
        }
        else
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0f)
            {
                StopAllCoroutines();
                Die();
            }
        }

    }

    void Die()
    {
        IsAlive = false;
        AudioSourceDeath.Play();

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        DisableComponents();

        Destroy(gameObject, 0.2f);
    }

    void DisableComponents()
    {
        foreach (var component in _componentsToDisableDeath)
        {
            component.enabled = false;
        }
    }

    IEnumerator ShiledRegenCounter()
    {
        yield return new WaitForSeconds(ShieldRegenStart);
        canRegenShield = true;
    }
}
