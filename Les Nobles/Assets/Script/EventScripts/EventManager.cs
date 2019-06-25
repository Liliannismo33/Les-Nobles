using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager s_Singleton;

    public int actualStepFirstEvent = 0;
    public int actualStepDoudouEvent = 0;
    public int actualStepArmoireEvent = 0;
    public int actualStepPhoneEvent = 0;
    public bool powerOff = false;


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
		
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    public void SetpowerOff()
    {
        powerOff = true;
    }

    public void SetPowerOn()
    {
        powerOff = false;
    }
}