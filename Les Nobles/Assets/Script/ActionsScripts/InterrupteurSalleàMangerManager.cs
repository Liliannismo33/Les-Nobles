using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurSalleàMangerManager : MonoBehaviour {

    public AudioClip interrupteurSound;
    public GameObject lightsToTurnOff;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        InteractionController.s_Singleton.getTarget = InteractionController.s_Singleton.ReturnSpottedObject();

        if (OVRInput.GetDown(OVRInput.Button.Two) && InteractionController.s_Singleton.getTarget.CompareTag("InterrupteurSalleàManger"))
        {
            AudioManager.s_Singleton.PlayClip(interrupteurSound);
            lightsToTurnOff.SetActive(!lightsToTurnOff.activeSelf);
        }

    }
}
