using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : MonoBehaviour, IPowerUpEffect
{
    public PowerUp PowerUp;
    public float IncreaseHealthCapacity;

    public void Effect()
    {
        PowerUp.PlayerObject.GetComponent<Target>().MaxHealth += IncreaseHealthCapacity;
        PowerUp.PlayerObject.GetComponent<Target>().CurrentHealth += IncreaseHealthCapacity;
    }
}
