using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMaisonCraque : MonoBehaviour {

    public List<AudioClip> craquementSounds;
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
        int audioToPlay = Random.Range(0, craquementSounds.Capacity);
        AudioManagerSecondary.s_Singleton.PlayClip(craquementSounds[audioToPlay]);
        gameObject.GetComponent<Collider>().enabled = false;
        waitForRespawn = true;
    }

}
