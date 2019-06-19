using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using UnityEngine.AI;


public class InteractionController : MonoBehaviour {

    //public List<HighlightedObject> highlightedObject = new List<HighlightedObject>();
    //public HighlightedObject[] highlightedObject;
    //public ParticleSystem particleSysteme;
    public float raycastDistance;
    public GameObject key;
    public HighlightedObject highlightedObject; // Variable qui attends le script permettant d'allumer l'outliner
    public GameObject getTarget; // Variable qui attends le GameObject touché par le RayCast
    public int stepState; // État actuel de l'événement
    
    public AudioClip[] mySound;
    public AudioClip noLightsSound;
    public AudioClip clefFilleSound;
    public AudioClip doudouSoundFirst;

    //private NavMeshAgent myNMA;

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
        //myNMA = GetComponent<NavMeshAgent>();
        //particleSysteme.Stop();
        //stepState = EventManager.s_Singleton.actualStepFirstEvent; //synchronisation entre état actuel de l'événement ici et le même dans EventManager
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (IntroManager.isIntroEnded == true)
            {
                /*Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit yes;
                if (Physics.Raycast(ray, out yes, 10f))
                {
                    //Debug.Log(gameObject.name);
                    if (OVRInput.GetDown(OVRInput.Button.Two))
                    {
                        myNMA.destination = yes.point;
                        Debug.Log(myNMA.destination);
                    }
                }*/

            getTarget = ReturnSpottedObject(); // Actualisation permanente du RayCast
            if (getTarget != null && getTarget.layer == 9)
            {
                highlightedObject = getTarget.GetComponent<HighlightedObject>();
                if (highlightedObject != null)
                {
                    highlightedObject/*[0]*/.launchOutliner(); //Allume l'outliner de l'objet actuellement ciblé
                }
                
                if (getTarget.CompareTag("PetiteFille"))
                {
                    //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red, 5f);
                    //if (!particleSysteme.isPlaying)
                    //particleSysteme.Play();
                }

                if (OVRInput.GetDown(OVRInput.Button.Two))
                {
                    if (getTarget.CompareTag("PetiteFille")) // Si le RayCast touche un objet dont le Tag est PetiteFille, alors joue un code précis
                    {
                        if (EventManager.s_Singleton.actualStepFirstEvent == 1) // Si l'étape de l'événement est la première étape...
                        {
                            Debug.Log("Passage à l'étape suivante, guignol");
                            AudioManager.s_Singleton.PlayClip(clefFilleSound);
                            EventManager.s_Singleton.actualStepFirstEvent++; // ... alors l'événement passe à l'étape suivante
                            Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
                            key.SetActive(true);
                            key = null;
                        }


                        else if (EventManager.s_Singleton.actualStepFirstEvent >= 2 && EventManager.s_Singleton.actualStepFirstEvent <= 3)
                        {
                            AudioManager.s_Singleton.PlayClip(noLightsSound);
                        }

                        else if (EventManager.s_Singleton.actualStepFirstEvent == 4) // Si l'étape de l'événement est la dernière étape...
                        {
                            Debug.Log("Event terminé gg");
                            EventManager.s_Singleton.actualStepFirstEvent++; // ... alors l'événement passe à l'étape suivante (donc terminé)
                            EventManager.s_Singleton.actualStepDoudouEvent++;
                            AudioManager.s_Singleton.PlayClip(doudouSoundFirst);
                            Debug.Log("Doudou =" + EventManager.s_Singleton.actualStepDoudouEvent);
                            Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
                        }

                        else
                        {
                            // ici on souhaite faire parler la petite fille (car le joueur intéragit avec elle)
                            Debug.Log("Tu parles à la petite fille");
                            int audioToPlay = Random.Range(0, mySound.Length);
                            AudioManager.s_Singleton.PlayClip(mySound[audioToPlay]);
                        }
                    }
                }
            }
            else
            {
                if (highlightedObject != null)
                {
                    highlightedObject/*[0]*/.stopOutliner(); // arrête l'outliner de l'objet ciblé lorsque le RayCast ne cible plus rien
                }
            }
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