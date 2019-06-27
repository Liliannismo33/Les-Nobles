using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {

    public AudioClip voisinSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionHand") && EventManager.s_Singleton.actualStepPhoneEvent == 1)
        {
             AudioManager.s_Singleton.PlayClip(voisinSound);
             EventManager.s_Singleton.actualStepPhoneEvent++;
        }
    }
}