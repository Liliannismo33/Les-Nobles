using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static bool eventIsActive = false;
    public bool firstStep = false;

    public static EventManager s_Singleton;

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
		
        if (eventIsActive)
        {
            Debug.Log("Jambon");  
            if (firstStep)
            {
                Debug.Log("Etape 1 terminée");
            }
            eventIsActive = false;
        }

    }
}