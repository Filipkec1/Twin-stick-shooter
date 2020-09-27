using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float MovmentSpeed = 10f;

    public Rigidbody2D RB;
    public Camera Cam;

    Vector2 _movment;
    Vector2 _mousePos;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }


    // Triger movment.
    void Update()
    {
        if (PauseMenu.IsGamePoused)
        {
            return;
        }

        _movment.x = Input.GetAxisRaw("Horizontal");
        _movment.y = Input.GetAxisRaw("Vertical");

        _mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Move player.
    void FixedUpdate()
    {

        RB.MovePosition(RB.position + _movment * MovmentSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = _mousePos - RB.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        RB.rotation = angle;
    }
}
