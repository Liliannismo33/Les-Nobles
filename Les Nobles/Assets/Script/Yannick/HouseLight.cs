using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLight : MonoBehaviour {

    public List<Light> myLights;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchOnMyLights()
    {
        foreach (Light myL in myLights)
        {
            myL.enabled = true;
        }
    }

    public void SwitchOffMyLights ()
    {
        foreach (Light myL in myLights)
        {
            myL.enabled = false;
        }
    }
}
