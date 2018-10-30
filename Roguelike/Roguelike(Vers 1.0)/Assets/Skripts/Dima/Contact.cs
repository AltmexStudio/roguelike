using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour {

    // Use this for initialization
    bool indicator = false;

    void OnCollisionEnter()
    {
        indicator = true;
    }
    // Update is called once per frame
    void Update () {
        if (indicator == true)
        {
            Debug.Log("hui");
        }

	}
}
