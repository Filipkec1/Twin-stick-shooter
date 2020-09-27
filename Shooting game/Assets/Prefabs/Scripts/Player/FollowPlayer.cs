using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform PlayerTarget;

    public float SmoothSpeed = 0.125f;

    void FixedUpdate()
    {
        if (PlayerTarget == null)
        {
            return;
        }

        Vector2 playerPosition = PlayerTarget.position;
        Vector2 followPosition = Vector2.Lerp(transform.position, playerPosition, SmoothSpeed);
        transform.position = followPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
