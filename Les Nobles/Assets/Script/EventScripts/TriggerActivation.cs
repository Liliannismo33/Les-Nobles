using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour {

    public GameObject firstEventTrigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        EventManager.eventIsActive = true;
        firstEventTrigger.SetActive (!firstEventTrigger.activeSelf);
    }


}
