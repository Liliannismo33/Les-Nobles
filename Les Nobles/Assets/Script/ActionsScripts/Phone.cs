using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger");

        if (other.CompareTag("InteractionHand") && EventManager.s_Singleton.actualStepPhoneEvent == 1)
        {
             //JOUER LE SON DU VOISIN CE CON
             Debug.Log("Telephone glauque");
             EventManager.s_Singleton.actualStepPhoneEvent++;
        }
    }
}
