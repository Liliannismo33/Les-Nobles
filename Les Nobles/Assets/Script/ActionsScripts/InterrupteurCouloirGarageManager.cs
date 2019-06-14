using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurCouloirGarageManager : MonoBehaviour {

    public AudioClip interrupteurSound;
    //public GameObject lightsToTurnOff;
    public List<HouseLight> houseLights;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        InteractionController.s_Singleton.getTarget = InteractionController.s_Singleton.ReturnSpottedObject();

        if (OVRInput.GetDown(OVRInput.Button.Two) && InteractionController.s_Singleton.getTarget.CompareTag("InterrupteurCouloirGarage") && EventManager.s_Singleton.actualStepFirstEvent != 1 && EventManager.s_Singleton.actualStepFirstEvent != 2 && EventManager.s_Singleton.actualStepFirstEvent != 3)
        {
            AudioManager.s_Singleton.PlayClip(interrupteurSound);

            foreach (HouseLight hlight in houseLights)
            {
                hlight.SwitchLightState();
            }

        }
    }
}
