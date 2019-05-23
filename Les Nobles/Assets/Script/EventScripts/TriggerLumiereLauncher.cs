using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLumiereLauncher : MonoBehaviour {

    public GameObject lightsOff;
    private Light lights;

	// Use this for initialization
	void Start () {
        lights = lightsOff.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        EventManager.s_Singleton.actualStepFirstEvent++;
        lightsOff.SetActive(!lightsOff.activeSelf);
        Debug.Log("Lumière éteinte");
        Destroy(gameObject);
    }
}
