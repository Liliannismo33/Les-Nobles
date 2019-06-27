using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoudouNeed : MonoBehaviour {

    public AudioClip doudouNeedSound;
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
                Debug.Log("timer fini");
                timerBeforeRespawn = 0;
                waitForRespawn = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (EventManager.s_Singleton.actualStepDoudouEvent == 1)
        {
            AudioManager.s_Singleton.PlayClip(doudouNeedSound);
            gameObject.GetComponent<Collider>().enabled = false;
            waitForRespawn = true;
        }
    }
}
