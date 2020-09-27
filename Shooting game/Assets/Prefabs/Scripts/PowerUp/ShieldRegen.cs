using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRegen : MonoBehaviour, IPowerUpEffect
{
    public PowerUp PowerUp;
    public float IncreaseShiledCapacity;

    public void Effect()
    {
        PowerUp.PlayerObject.GetComponent<Target>().MaxShield += IncreaseShiledCapacity;
    }
}
