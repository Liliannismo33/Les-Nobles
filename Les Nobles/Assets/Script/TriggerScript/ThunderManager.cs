using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderManager : MonoBehaviour {

    public GameObject hlight;
    public AudioClip thunderSound00;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(HlightEnabler());
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
        AudioManager.s_Singleton.PlayClip(thunderSound00);
        Destroy(gameObject);
    }
}
