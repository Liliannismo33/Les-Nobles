using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupteur : MonoBehaviour {

    public AudioClip interrupteurSound;
    public List<HouseLight> houseLights;
    private bool canBeUsed = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.Two) && !EventManager.s_Singleton.powerOff && canBeUsed)
        {
            AudioManager.s_Singleton.PlayClip(interrupteurSound);

            foreach (HouseLight hlight in houseLights)
            {
                hlight.SwitchLightState();
            }
            //lightsToTurnOff.SetActive(!lightsToTurnOff.activeSelf);
            //lightsToTurnOff01.SetActive(!lightsToTurnOff01.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionHand"))
        {
            canBeUsed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractionHand"))
        {
            canBeUsed = false;
        }
    }


}