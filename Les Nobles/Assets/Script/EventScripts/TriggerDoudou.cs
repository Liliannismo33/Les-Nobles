using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoudou : MonoBehaviour {

    public AudioClip doudouEndSound;
    public GameObject doudou;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other == doudou && EventManager.s_Singleton.actualStepDoudouEvent == 1)
        {
            AudioManager.s_Singleton.PlayClip(doudouEndSound);
            EventManager.s_Singleton.actualStepDoudouEvent++;
            Debug.Log("Doudou event is éteint");
            Destroy(gameObject);
        }
    }
}