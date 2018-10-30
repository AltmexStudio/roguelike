using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        transform.position = new Vector3(x, y, transform.position.z);
		
	}
}
