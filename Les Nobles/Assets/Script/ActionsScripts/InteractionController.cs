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
	void FixedUpdate () {
        
        getTarget = ReturnSpottedObject();
        if (getTarget !=null)
        {
            if (getTarget.CompareTag("PetiteFille"))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red, 5f);
                if (!particleSysteme.isPlaying)
                    particleSysteme.Play();
            }
            else
            {
                particleSysteme.Stop();
            }
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                if (getTarget.CompareTag("PetiteFille"))
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
    }

    private GameObject ReturnSpottedObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 10f))
        {
            CreateOutline outlineScript = hit.collider.gameObject.GetComponent<CreateOutline>();
            if (outlineScript != null)
            {
                outlineScript.ActivateOutline();
            }
            return hit.collider.gameObject;
        }
        return null;
    }
}