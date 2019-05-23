using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisjoncteurController : MonoBehaviour {

    public GameObject lightsOn;

    public GameObject moonLights;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        InteractionController.s_Singleton.getTarget = InteractionController.s_Singleton.ReturnSpottedObject();

        if (OVRInput.GetDown(OVRInput.Button.One) && EventManager.s_Singleton.actualStepFirstEvent == 3 && InteractionController.s_Singleton.getTarget.CompareTag("Disjoncteur"))
        {
            lightsOn.SetActive(!lightsOn.activeSelf);
            moonLights.SetActive(!moonLights.activeSelf);
            EventManager.s_Singleton.actualStepFirstEvent++;
        }
    }
}