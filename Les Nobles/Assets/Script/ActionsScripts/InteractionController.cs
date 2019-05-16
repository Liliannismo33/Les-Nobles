using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    public GameObject getTarget;
    public int test;

	// Use this for initialization
	void Start () {
        test = EventManager.s_Singleton.actualStepFirstEvent;
    }
	
	// Update is called once per frame
	void Update () {
        
    if (Input.GetMouseButtonDown(0))
        {
             RaycastHit hitInfo;
             getTarget = ReturnClickedObject(out hitInfo);
             if ((getTarget != null) && (getTarget.tag == "PetiteFille"))
                {
                    if (test == 0)
                        {
                            Debug.Log("Passage à l'étape suivante, guignol");
                            test++;
                        }
                    else
                {
                    // ici on souhaite faire parler la petite fille (car le joueur intéragit avec elle)
                    Debug.Log("Tu parle à la petite fille");
                }
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