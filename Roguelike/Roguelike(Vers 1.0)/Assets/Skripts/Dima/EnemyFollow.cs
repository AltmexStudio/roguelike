using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    public int hp;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Vector3.Distance(transform.position, player.transform.position) <= 2)
        {
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime / 2.0f);
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= 0.5)
            hp -= 1;
	}
}
