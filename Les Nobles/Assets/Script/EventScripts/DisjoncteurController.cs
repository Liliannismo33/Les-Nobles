﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisjoncteurController : MonoBehaviour {

    //public GameObject lightsOn;

    public GameObject moonLights;

    public AudioClip mySound;
    public AudioClip rallumageSound;

    public List<HouseLight> houseLights;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.Two) && EventManager.s_Singleton.actualStepFirstEvent == 3 && InteractionController.s_Singleton.getTarget == gameObject)
        {
            foreach (HouseLight hlight in houseLights)
            {
                hlight.SwitchOnMyLights();
            }
            //moonLights.SetActive(false);
            EventManager.s_Singleton.powerOff = false;
            EventManager.s_Singleton.actualStepFirstEvent++;
            AudioManager.s_Singleton.PlayClip(rallumageSound);
            AudioManager.s_Singleton.PlayClip(mySound);
        }
    }
}