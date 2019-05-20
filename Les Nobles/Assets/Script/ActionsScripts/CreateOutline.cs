using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOutline : MonoBehaviour {

    private GameObject outline;

	// Use this for initialization
	void Start () {
        outline = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        outline.transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
	}

    public void ActivateOutline()
    {
        outline.SetActive(true);
    }
}