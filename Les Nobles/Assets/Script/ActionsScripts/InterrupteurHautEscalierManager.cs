using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurHautEscalierManager : MonoBehaviour {

    public AudioClip interrupteurSound;
    public GameObject lightsToTurnOff;
    public GameObject lightsToTurnOff01;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        InteractionController.s_Singleton.getTarget = InteractionController.s_Singleton.ReturnSpottedObject();

        if (OVRInput.GetDown(OVRInput.Button.One) && InteractionController.s_Singleton.getTarget.CompareTag("InterrupteurHautEscalier"))
        {
            AudioManager.s_Singleton.PlayClip(interrupteurSound);
            lightsToTurnOff.SetActive(!lightsToTurnOff.activeSelf);
            lightsToTurnOff01.SetActive(!lightsToTurnOff01.activeSelf);
        }

    }
}
