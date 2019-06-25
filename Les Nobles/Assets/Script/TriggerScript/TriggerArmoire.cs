using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArmoire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (EventManager.s_Singleton.actualStepArmoireEvent == 1)
        {
            //JOUER SON PETITE FILLE REGARDER DANS ARMOIRE
            EventManager.s_Singleton.actualStepArmoireEvent++;
            gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log(EventManager.s_Singleton.actualStepArmoireEvent);
        }

        else if (EventManager.s_Singleton.actualStepArmoireEvent == 2)
        {
            //C'EST BON C'EST SAFE DANS L'ARMOIRE
            EventManager.s_Singleton.actualStepArmoireEvent++;
            gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log(EventManager.s_Singleton.actualStepArmoireEvent);
        }
    }

}
