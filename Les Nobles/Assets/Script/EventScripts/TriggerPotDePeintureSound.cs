using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPotDePeintureSound : MonoBehaviour {

    public AudioClip potTombe;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
         AudioManager.s_Singleton.PlayClip(potTombe);
         gameObject.GetComponent<Collider>().enabled = false;
    }

}
