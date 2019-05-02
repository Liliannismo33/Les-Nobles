using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    public GameObject getTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                getTarget = ReturnClickedObject(out hitInfo);
                    if ((getTarget != null) && (getTarget.tag == "PetiteFille"))
                {
                    // ici on souhaite faire parler la petite fille (car le joueur intéragit avec elle)
                    Debug.Log("Tu parle à la petite fille");
                    EventManager.s_Singleton.firstStep = true;
                }
            }        
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10f))
        {
            target = hit.collider.gameObject;
            Debug.Log ("objet détecté");
        }
        return target;
    }
}