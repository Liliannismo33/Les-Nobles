using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteraction : MonoBehaviour
{
    public AudioClip[] mySound; // Tableau renseignant toutes les voice-lanes de la petite fille hors évenement
    public AudioClip clefFilleSound; // La petite fille indique où se trouve la clé et ce que le joueur doit en faire
    public AudioClip noLightsSound; // La petite fille se plaind qu'il fait noir
    public AudioClip doudouSoundFirst; // La petite fille demande son doudou
    public GameObject key;
    private bool canTalk;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        canTalk = false;

        if (canTalk)
        {
            if (EventManager.s_Singleton.actualStepFirstEvent == 1) // Si l'étape de l'événement est l'étape n°1, alors...
            {
                AudioManager.s_Singleton.PlayClip(clefFilleSound); // Joue le son renseigné en appelant la fonction PlayClip dans la classe AudioManager
                EventManager.s_Singleton.actualStepFirstEvent++; // L'événement passe à l'étape suivante
                Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
                key.SetActive(true); // Fait apparaître le GameObject key
                key = null;
            }


            else if (EventManager.s_Singleton.actualStepFirstEvent == 2 || EventManager.s_Singleton.actualStepFirstEvent == 3) // Si l'etape de l'évenement est à l'étape n°2 ou n°3, alors...
            {
                AudioManager.s_Singleton.PlayClip(noLightsSound);
            }

            else if (EventManager.s_Singleton.actualStepFirstEvent == 4) // Si l'étape de l'événement est l'étape 4, alors...
            {
                EventManager.s_Singleton.actualStepFirstEvent++; // L'événement passe à l'étape suivante (donc terminé dans ce cas)
                EventManager.s_Singleton.actualStepDoudouEvent++; // L'événement DoudouEvent passe à l'étape suivante
                AudioManager.s_Singleton.PlayClip(doudouSoundFirst);
            }

            else
            {
                int audioToPlay = Random.Range(0, mySound.Length); // On attribue à une variable int une valeur aléatoire comprise entre l'index 0 et l'index maximum du tableau mySound
                AudioManager.s_Singleton.PlayClip(mySound[audioToPlay]); // On joue le son correspondant à l'index du tableau attribué à l'int audioToPlay
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTalk = true;
    }
}