using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEscalierGrinçant : MonoBehaviour {

    public AudioClip escalierSound;
    private bool waitForRespawn = false;
    private float timerBeforeRespawn;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (waitForRespawn)
        {
            timerBeforeRespawn += Time.deltaTime;

            if (timerBeforeRespawn >= 5f)
            {
                gameObject.GetComponent<Collider>().enabled = true;
                timerBeforeRespawn = 0;
                waitForRespawn = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.s_Singleton.PlayClip(escalierSound);
        gameObject.GetComponent<Collider>().enabled = false;
        waitForRespawn = true;
    }
}
