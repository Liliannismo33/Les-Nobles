using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPotTombe : MonoBehaviour {

    public GameObject supportPotDePeinture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        Destroy(supportPotDePeinture);
        Destroy(gameObject);
    }

}
