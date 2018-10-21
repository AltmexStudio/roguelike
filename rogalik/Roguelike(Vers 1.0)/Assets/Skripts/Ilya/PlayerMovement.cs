using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float maxSpeed = 1.0f;

    void Start()
    {

    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal * maxSpeed + Vector3.up * joystick.Vertical * maxSpeed) * maxSpeed;

        if (moveVector != Vector3.zero)
        {
            transform.Translate(moveVector * maxSpeed * Time.deltaTime, Space.World);
        }
    }
}
