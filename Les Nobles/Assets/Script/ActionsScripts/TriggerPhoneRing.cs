using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhoneRing : MonoBehaviour {

    public Light phoneLight;
    public Color color01 = Color.green;
    private Color color02;

    // Use this for initialization
    void Start () {
        color02 = phoneLight.GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In Trigger");
        //Jouer la sonnerie du téléphone, faire clignoter la lumière du téléphone, détruire le trigger.
        phoneLight.GetComponent<Light>().intensity = 6;
        phoneLight.GetComponent<Light>().color = color01;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Out Trigger");
    //    phoneLight.GetComponent<Light>().intensity = 1;
    //    phoneLight.GetComponent<Light>().color = color02;
    //}
}