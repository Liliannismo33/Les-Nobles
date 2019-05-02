using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerKeyboard : MonoBehaviour {


    public int speed = 2;

    // Use this for initialization
    void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, -0.1f);
        }


    }
}
