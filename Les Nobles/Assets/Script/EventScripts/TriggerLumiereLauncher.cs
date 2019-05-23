using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLumiereLauncher : MonoBehaviour {

    public GameObject moonLights;
    public GameObject lightsOff;
    private Light lights;

    public AudioClip mySound;

	// Use this for initialization
	void Start () {
        lights = lightsOff.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.s_Singleton.PlayClip(mySound);
        EventManager.s_Singleton.actualStepFirstEvent++;
        lightsOff.SetActive(!lightsOff.activeSelf);
        moonLights.SetActive(!moonLights.activeSelf);
        Debug.Log("Lumière éteinte");
        Destroy(gameObject);
    }
}
