/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour {

    private NavMeshAgent myNMA;

	// Use this for initialization
	void Start () {
        myNMA = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit yes;
        if (Physics.Raycast(ray, out yes, 10f))
        {
            if(Input.GetMouseButtonDown(0))
            {
                myNMA.destination = yes.point;
            }
        }
    }
}*/
