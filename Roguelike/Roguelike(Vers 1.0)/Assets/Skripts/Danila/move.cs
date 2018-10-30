using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public Joystick joystick;
    public float maxSpeed = 1.0f;
    // Use this for initialization

    // Update is called once per frame
    void Update ()
    {
        Vector3 moveVector = ((Vector3.right * joystick.Horizontal * maxSpeed) + Vector3.up * joystick.Vertical * maxSpeed) * maxSpeed;
        
        if ((moveVector != Vector3.zero))
        {
            transform.Translate(moveVector * maxSpeed * Time.deltaTime, Space.World);
        }
    }
}
