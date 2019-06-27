using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLumiereLauncher : MonoBehaviour {

    public GameObject moonLights;
    public GameObject triggerThunder;
    public GameObject hlight;

    //public GameObject lightsOff;
    public AudioClip thunderLightsOff;
    private Light lights;
    private bool waitForPlaySound = false;
    private float timerBeforePlay = 0;

    //YANNICK
    public List<HouseLight> houseLights;
    //ENDYANNICK

    public AudioClip extinctionSound;
    public AudioClip mySound;

	// Use this for initialization
	void Start () {
        //lights = lightsOff.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {


        if (timerBeforePlay == 2)
        {
            AudioManager.s_Singleton.PlayClip(mySound);
            EventManager.s_Singleton.actualStepFirstEvent++;
            
            Debug.Log("Lumière éteinte");
            Destroy(gameObject);
        }

        if (waitForPlaySound)
        {
            timerBeforePlay += Time.deltaTime;

            if (timerBeforePlay >= 2f)
            {
                Debug.Log("timer fini");
                timerBeforePlay = 2;
                waitForPlaySound = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        foreach (HouseLight hlight in houseLights)
        {
            hlight.SwitchOffMyLights();
        }
        StartCoroutine(HlightEnabler());
        triggerThunder.SetActive(true);
        EventManager.s_Singleton.powerOff = true;
        moonLights.SetActive(true);
        AudioManager.s_Singleton.PlayClip(extinctionSound);
        waitForPlaySound = true;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    IEnumerator HlightEnabler()
    {
        hlight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        hlight.SetActive(false);

        yield return new WaitForSeconds(0.05f);

        hlight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        hlight.SetActive(false);
        AudioManagerSecondary.s_Singleton.PlayClip(thunderLightsOff);
    }
}