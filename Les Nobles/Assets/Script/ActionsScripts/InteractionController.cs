using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using UnityEngine.AI;


public class InteractionController : MonoBehaviour {

    [Header ("Raycast")]

    public float raycastDistance; // Variable déterminant la longeur du Raycast
    public GameObject getTarget; // Variable qui stock le GameObject touché par le RayCast
    // HighlightedObject highlightedObject; // Variable qui attends le script permettant d'allumer l'outliner

    [Space]

    [Header("Sons")]

    public AudioClip debutArmoireEvent;
    public AudioClip[] mySound; // Tableau renseignant toutes les voice-lanes de la petite fille hors évenement
    public AudioClip noLightsSound; // La petite fille se plaind qu'il fait noir
    public AudioClip clefFilleSound; // La petite fille indique où se trouve la clé et ce que le joueur doit en faire
    public AudioClip doudouSoundFirst; // La petite fille demande son doudou

    [Space]
    [Space]

    public GameObject key;
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

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        //if (IntroManager.isIntroEnded == true) // Si l'introduction est terminée, alors...
            //{

            if (EventManager.s_Singleton.actualStepArmoireEvent == 1)
            {
                //JOUER SON PETITE FILLE DEMANDANT DE VENIR
            }

            /*Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit yes;
            if (Physics.Raycast(ray, out yes, 10f))
            {
                if (OVRInput.GetDown(OVRInput.Button.Two))
                {
                    myNMA.destination = yes.point;
                }
            }*/

            getTarget = ReturnSpottedObject(); // Actualisation permanente du RayCast
            if (getTarget != null) // Si le RayCast renseigne un objet et que celui-ci est sur le layer 9 (InteractiveObject), alors...
            {
                if (getTarget.CompareTag("DessinEvent") && EventManager.s_Singleton.actualStepArmoireEvent < 1 && EventManager.s_Singleton.actualStepDoudouEvent == 2)
                {
                    AudioManager.s_Singleton.PlayClip(debutArmoireEvent);
                    EventManager.s_Singleton.actualStepArmoireEvent++;
                    //Debug.Log(EventManager.s_Singleton.actualStepArmoireEvent);
                    //return;
                }

                //highlightedObject = getTarget.GetComponent<HighlightedObject>(); // ... On récupère le composant permettant l'activation de l'Highliner
                //if (highlightedObject != null) // Si il y a un composant HiglightedObject sur l'objet renseigné par le RayCast, alors...
                //{
                //    highlightedObject/*[0]*/.launchOutliner(); // Allume l'outliner de l'objet actuellement ciblé
                //}
                
                //if (getTarget.CompareTag("PetiteFille")) // Si l'objet touché porte le tag PetiteFille, alors...
                //{
                //    //if (!particleSysteme.isPlaying)
                //    //particleSysteme.Play();
                //}

                if (OVRInput.GetDown(OVRInput.Button.Two)) // Si on appuie sur la touche n°2 du controller, alors...
                {                   
                    if (getTarget.CompareTag("PetiteFille")) // Si l'objet touché porte le tag PetiteFille, alors...
                    {
                        if (EventManager.s_Singleton.actualStepFirstEvent == 1) // Si l'étape de l'événement est l'étape n°1, alors...
                        {
                            AudioManager.s_Singleton.PlayClip(clefFilleSound); // Joue le son renseigné en appelant la fonction PlayClip dans la classe AudioManager
                            EventManager.s_Singleton.actualStepFirstEvent++; // L'événement passe à l'étape suivante
                            Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
                            key.SetActive(true); // Fait apparaître le GameObject key
                            key = null;
                        }


                        //if (EventManager.s_Singleton.actualStepFirstEvent == 2 || EventManager.s_Singleton.actualStepFirstEvent == 3) // Si l'etape de l'évenement est à l'étape n°2 ou n°3, alors...
                        //{
                        //    AudioManager.s_Singleton.PlayClip(noLightsSound);
                        //}

                        if (EventManager.s_Singleton.actualStepFirstEvent == 4) // Si l'étape de l'événement est l'étape 4, alors...
                        {
                            EventManager.s_Singleton.actualStepFirstEvent++; // L'événement passe à l'étape suivante (donc terminé dans ce cas)
                            EventManager.s_Singleton.actualStepDoudouEvent++; // L'événement DoudouEvent passe à l'étape suivante
                            AudioManager.s_Singleton.PlayClip(doudouSoundFirst);
                        }

                        //else
                        //{
                        //    int audioToPlay = Random.Range(0, mySound.Length); // On attribue à une variable int une valeur aléatoire comprise entre l'index 0 et l'index maximum du tableau mySound
                        //    AudioManager.s_Singleton.PlayClip(mySound[audioToPlay]); // On joue le son correspondant à l'index du tableau attribué à l'int audioToPlay
                        //}
                    }
                }
            }
            //else
            //{
            //    if (highlightedObject != null)
            //    {
            //        highlightedObject.stopOutliner(); // arrête l'outliner de l'objet ciblé lorsque le RayCast ne cible plus rien
            //    }
            //}
        //}
    }

        public GameObject ReturnSpottedObject() // Fonction qui gère le RayCast
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // Création du Raycast qui part de la caméra et va en avant
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, raycastDistance)) // Si le RayCast touche quelque chose, alors...
        {
            return hit.collider.gameObject; // Retourne l'info du GameObject touché
        }
        return null; // Ne retourne rien si le RayCast ne touche rien
    }
}