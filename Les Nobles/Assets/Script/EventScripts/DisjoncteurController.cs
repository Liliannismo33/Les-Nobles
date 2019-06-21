using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisjoncteurController : MonoBehaviour {

    private bool canBeUsed = false;
    public GameObject triggerThunder;

    [Header ("Sons")]

    public AudioClip mySound;
    public AudioClip rallumageSound;

    [Space]

    [Header ("Lumières")]

    public List<HouseLight> houseLights; // Liste renseignant tous les composants Lights sur les GameObjects renseigné dans la liste


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.Two) && EventManager.s_Singleton.powerOff && canBeUsed) // Si tu appuies sur le bouton n°2 du controller et que powerOff est vrai et que canBeUsed est vrai, alors...
        {
            foreach (HouseLight hlight in houseLights) // Récupère la classe Houselight nommé hlight dans la liste houseLights et applique les lignes suivantes pour tous les objets concernés
            {
                hlight.SwitchOnMyLights(); // Active la fonction SwitchOnMyLights() dans hlight
            }
            triggerThunder.SetActive(true);
            EventManager.s_Singleton.powerOff = false;
            EventManager.s_Singleton.actualStepFirstEvent++;
            AudioManager.s_Singleton.PlayClip(rallumageSound);
            AudioManager.s_Singleton.PlayClip(mySound);
        }
    }

    private void OnTriggerEnter(Collider other) // Quand un collider entre dans le trigger du porteur de ce script, alors...
    {
        if (other.CompareTag("InteractionHand")) // Si le collider porte le tag InteractionHand, alors...
        {
            canBeUsed = true;
        }
    }

    private void OnTriggerExit(Collider other) // Quand un collider sort du trigger du porteur de ce script, alors...
    {
        if (other.CompareTag("InteractionHand")) // Si le collider porte le tag InteractionHand, alors...
        {
            canBeUsed = false;
        }
    }
}