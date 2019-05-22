using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;


public class InteractionController : MonoBehaviour {

    //public List<HighlightedObject> highlightedObject = new List<HighlightedObject>();
    //public HighlightedObject[] highlightedObject;
    //public ParticleSystem particleSysteme;
    public float raycastDistance;
    public GameObject key;
    public HighlightedObject highlightedObject; // Variable qui attends le script permettant d'allumer l'outliner
    public GameObject getTarget; // Variable qui attends le GameObject touché par le RayCast
    public int stepState; // État actuel de l'événement

    public static InteractionController s_Singleton;

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
        //particleSysteme.Stop();
        //stepState = EventManager.s_Singleton.actualStepFirstEvent; //synchronisation entre état actuel de l'événement ici et le même dans EventManager
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        getTarget = ReturnSpottedObject(); // Actualisation permanente du RayCast
        if (getTarget !=null && getTarget.layer == 9)
        {
            highlightedObject = getTarget.GetComponent<HighlightedObject>(); 
            highlightedObject/*[0]*/.launchOutliner(); //Allume l'outliner de l'objet actuellement ciblé
            if (getTarget.CompareTag("PetiteFille"))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red, 5f);
                //if (!particleSysteme.isPlaying)
                    //particleSysteme.Play();
            }
            
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                if (getTarget.CompareTag("PetiteFille")) // Si le RayCast touche un objet dont le Tag est PetiteFille, alors joue un code précis
                {
                    if (EventManager.s_Singleton.actualStepFirstEvent == 1) // Si l'étape de l'événement est la première étape...
                    {
                        Debug.Log("Passage à l'étape suivante, guignol");
                        EventManager.s_Singleton.actualStepFirstEvent++; // ... alors l'événement passe à l'étape suivante
                        Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
                        key.SetActive(true);
                        key = null;
                    }
                    if (EventManager.s_Singleton.actualStepFirstEvent == 4) // Si l'étape de l'événement est la dernière étape...
                    {
                        Debug.Log("Event terminé gg");
                        EventManager.s_Singleton.actualStepFirstEvent++; // ... alors l'événement passe à l'étape suivante (donc terminé)
                        Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
                    }
                    else
                    {
                        // ici on souhaite faire parler la petite fille (car le joueur intéragit avec elle)
                        Debug.Log("Tu parles à la petite fille");
                    }
                }
            }
        }
        else
        {
            highlightedObject/*[0]*/.stopOutliner(); // arrête l'outliner de l'objet ciblé lorsque le RayCast ne cible plus rien
        }
    }

    public GameObject ReturnSpottedObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}