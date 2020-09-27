using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public PlayerMovment Player;

    public Shooting Shooting;

    public LayerMask PlayerMask;

    public float CurrentRotationSpeed;

    public float MaxRotationSpeed = 1f;
    public float MinRotationSpeed = 0.2f;


    float _distanceToPlayer;

    //Distance at which the enemy will start rotating.
    public float TargetingRange = 30f;

    //Can see player.
    public float SeeTarget;

    //Minimal distance.
    public float MinimalRange = 4.8f;

    //Distance at which the enemy will start firing.
    public float StartFiringRange = 20f;

    //Distance at which the enemy will stop firing.
    public float StopFiringRange = 25f;

    //Is in firing range of the player.
    bool isInRange = false;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<PlayerMovment>();
        SeeTarget = TargetingRange + 5f;
        _distanceToPlayer = Vector2.Distance(Player.transform.position, transform.position);
        CurrentRotationSpeed = MinRotationSpeed;
    }

    void FixedUpdate()
    {
        if(Player == null)
        {
            return;
        }
        _distanceToPlayer = Vector2.Distance(Player.transform.position, transform.position);
        CurrentRotationSpeed = RotationSpeed(_distanceToPlayer);
    }

    void Update()
    {

        if (Player == null)
        {
            return;
        }

        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        if (_distanceToPlayer > TargetingRange)
        {
            return;
        }

        float distCovered = Time.deltaTime * CurrentRotationSpeed;
        float fractionOfJourney = distCovered / _distanceToPlayer;

        transform.up = Vector3.Lerp(gameObject.transform.up, diff, fractionOfJourney);
        ShootCommand(Vector3.Angle(gameObject.transform.up, diff));
    }


    /// <summary>
    /// Chechk if the enemy can fier at the player.
    /// </summary>
    /// <param name="angle"> The angle between the front of the enemy and the player.</param>
    void ShootCommand(float angle)
    {
        if (_distanceToPlayer <= StartFiringRange)
        {
            isInRange = true;
        }

        if (_distanceToPlayer > StopFiringRange)
        {
            isInRange = false;
        }

        if (isInRange && (angle <20f))
        {
            Shooting.Shoot();
        }
    }

    /// <summary>
    /// Calculate the speed at which the turret rotates.
    /// </summary>
    /// <param name="distanceToPlayer">The distance between the enemy and the player.</param>
    /// <returns> Retruns the rotation speed of the enemy.</returns>
    float RotationSpeed(float distanceToPlayer)
    {
        float distancePercent = MaxRotationSpeed - (((MinRotationSpeed * (distanceToPlayer - MinimalRange)) / (TargetingRange - MinimalRange)));

        return distancePercent*100;
    }
}
