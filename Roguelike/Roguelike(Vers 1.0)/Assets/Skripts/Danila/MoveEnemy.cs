using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Use this for initialization
    void OnTrigerEnter2D (Collider2D collider)
    {
        
        if (collider.CompareTag("player"))
        {
          
            //var objs = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Player = objs[0];
            //transform.Translate(0, 0, Time.deltaTime);
            Debug.Log("her");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
