using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public static bool isIntroEnded = false;
    public Image introImage;
    public float timerBeforeLaunch;

    //public AudioClip introSound;

    private void Awake()
    {
        //AudioManager.s_Singleton.PlayClip(introSound);

    }

    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {

        timerBeforeLaunch -= Time.deltaTime;

        if (timerBeforeLaunch <= 0)
        {
            isIntroEnded = true;
            Destroy(introImage);
        }
	}
}