using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnomaly : MonoBehaviour {

    private Light anomaly;

	// Use this for initialization
	void Start () {
        anomaly = GetComponent<Light>();
        InvokeRepeating("ReduceIntensity", 1f, Random.Range(.3f, .2f));
        InvokeRepeating("UpgradeIntensity", 1f, Random.Range(.5f, .2f));
    }

    // Update is called once per frame
    void Update () {
        //anomaly.intensity += Time.deltaTime;
        if (anomaly.intensity <= .5f)
        {
            anomaly.intensity = .6f;
        }

        if (anomaly.intensity >= 2f)
        {
            anomaly.intensity = 1.9f;
        }
    }

    void UpgradeIntensity()
    {
        Debug.Log("Upgrade");
        var intensity = Random.Range(.1f, .5f);
        anomaly.intensity += intensity;
    }

    void ReduceIntensity()
    {
        Debug.Log("Reduce");
        var intensity = Random.Range(.1f, .5f);
        anomaly.intensity -= intensity;
    }
}