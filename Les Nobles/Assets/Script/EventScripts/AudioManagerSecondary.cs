using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSecondary : MonoBehaviour {

    private AudioSource mySAS;

    public static AudioManagerSecondary s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    // Use this for initialization
    void Start () {
        mySAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PlayClip(AudioClip newAC)
    {
        mySAS.clip = newAC;
        mySAS.Play();
    }

}
