using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArmoire : MonoBehaviour {

    public AudioClip mArmoireSound;
    public AudioClip safeArmoireSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (EventManager.s_Singleton.actualStepArmoireEvent == 1 && EventManager.s_Singleton.actualStepDoudouEvent == 2)
        {
            AudioManager.s_Singleton.PlayClip(mArmoireSound);
            EventManager.s_Singleton.actualStepArmoireEvent++;
            gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log(EventManager.s_Singleton.actualStepArmoireEvent);
        }

        else if (EventManager.s_Singleton.actualStepArmoireEvent == 2)
        {
            AudioManager.s_Singleton.PlayClip(safeArmoireSound);
            EventManager.s_Singleton.actualStepArmoireEvent++;
            gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log(EventManager.s_Singleton.actualStepArmoireEvent);
        }
    }

}
