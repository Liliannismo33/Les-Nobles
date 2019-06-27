using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhoneRing : MonoBehaviour {

    public AudioClip phoneRing;
    public GameObject phoneLightRDC;
    public GameObject phoneLightEtage;
    private Animator animEtage;
    private Animator animRDC;
    public Color color01 = Color.green;
    private Color color02 = Color.red;

    // Use this for initialization
    void Start () {

        animRDC.enabled = false;
        animEtage.enabled = false;
        color01 = phoneLightEtage.GetComponent<Light>().color;

        color01 = phoneLightEtage.GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update () {

        if(EventManager.s_Singleton.actualStepPhoneEvent == 2)
        {
            //StopCoroutine(phoneLightRDCEnabler());
            //StopCoroutine(phoneLightEtageEnabler());
            animRDC.enabled = false;
            animEtage.enabled = false;
            phoneLightEtage.GetComponent<Light>().color = color01;
            phoneLightEtage.GetComponent<Light>().color = color01;

            EventManager.s_Singleton.actualStepPhoneEvent++;
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (EventManager.s_Singleton.actualStepDoudouEvent == 2)
        {
            EventManager.s_Singleton.actualStepPhoneEvent++;
            AudioManager.s_Singleton.PlayClip(phoneRing);

            phoneLightRDC.GetComponent<Light>().intensity = 2;
            phoneLightRDC.GetComponent<Light>().color = color02;
            phoneLightEtage.GetComponent<Light>().intensity = 2;
            phoneLightEtage.GetComponent<Light>().color = color02;


            animRDC = phoneLightRDC.GetComponent<Animator>();
            animEtage = phoneLightEtage.GetComponent<Animator>();

            //animRDC.SetBool("canPlay", true);
            //animEtage.SetBool("canPlay", true);
            animRDC.enabled = true;
            animEtage.enabled = true;
            animRDC.Play("LightFlashing");
            animEtage.Play("LightFlashing");
            //StartCoroutine(phoneLightRDCEnabler());
            //StartCoroutine(phoneLightEtageEnabler());

            gameObject.GetComponent<Collider>().enabled = false;
        }      
    }

    //void Flashlight()
    //{
    //    phoneLightEtage.SetActive(false);
    //    new WaitForSeconds(1f);
    //    phoneLightEtage.SetActive(true);
    //}

    //private void EnableFlashlight()
    //{
    //    InvokeRepeating("FlashLight", 0, 1);
    //}

    //private void DisableFlashLight()
    //{
    //    CancelInvoke("FlashLight");
    //}
    //IEnumerator phoneLightEtageEnabler()
    //{
    //    phoneLightEtage.SetActive(false);
    //    yield return new WaitForSeconds(1f);
    //    phoneLightEtage.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //}

    //IEnumerator phoneLightRDCEnabler()
    //{
    //    phoneLightRDC.SetActive(false);
    //    yield return new WaitForSeconds(1f);
    //    phoneLightRDC.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Out Trigger");
    //    phoneLight.GetComponent<Light>().intensity = 1;
    //    phoneLight.GetComponent<Light>().color = color02;
    //}
}