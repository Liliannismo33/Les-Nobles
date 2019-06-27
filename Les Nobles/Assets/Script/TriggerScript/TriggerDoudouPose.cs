using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoudouPose : MonoBehaviour {

    public AudioClip dodoSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doudou") && EventManager.s_Singleton.actualStepDoudouEvent == 2)
        {
            EventManager.s_Singleton.isDoudouEventEnded = true;
            AudioManager.s_Singleton.PlayClip(dodoSound);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}