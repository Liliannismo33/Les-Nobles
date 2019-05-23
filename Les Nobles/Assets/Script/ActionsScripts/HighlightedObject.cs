using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class HighlightedObject : MonoBehaviour {

    protected Highlighter h;

    void Awake()
    {
        h = gameObject.AddComponent<Highlighter>();
    }

    // Use this for initialization
    void Start () {
        h.ConstantOffImmediate();
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void launchOutliner()
    {
        // Fade in constant highlighting
        h.ConstantOn(Color.white);
    }

    public void stopOutliner()
    {
        // Turn off constant highlighting
        h.ConstantOffImmediate();
    }

}