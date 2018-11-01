using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject camera;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = camera.transform.position.z;

        transform.position = new Vector3(x, y, z);

    }
}
