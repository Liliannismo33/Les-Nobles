using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionController : MonoBehaviour {

    public ParticleSystem particleSysteme;
    public GameObject getTarget;
    public int stepState; // État actuel de l'événement

	// Use this for initialization
	void Start () {
        particleSysteme.Stop();
        stepState = EventManager.s_Singleton.actualStepFirstEvent; //synchronisation entre état actuel de l'événement ici et le même dans EventManager
    }
	
	// Update is called once per frame
	void Update () {
 
    if (OVRInput.GetDown(OVRInput.Button.One))
        {
             getTarget = ReturnClickedObject();
             if ((getTarget != null) && (getTarget.tag == "PetiteFille"))
                {
                    if (stepState == 0)
                        {
                            Debug.Log("Passage à l'étape suivante, guignol");
                            stepState++;
                        }
                    else
                {
                    // ici on souhaite faire parler la petite fille (car le joueur intéragit avec elle)
                    Debug.Log("Tu parle à la petite fille");
                }
             }
        }        
    }

    GameObject ReturnClickedObject()
    {
        GameObject target = null;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            target = hit.collider.gameObject;
            particleSysteme.Play();
            Debug.Log ("objet détecté");
        }
        else
        {
            particleSysteme.Stop();
        }
        return target;
    }
}