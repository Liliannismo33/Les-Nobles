using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem; //NE PAS OUBLIER D'AJOUTER LA LIBRAIRIE HighlightingSystem.

public class HighlightedObject : MonoBehaviour {

    protected Highlighter h;

    void Awake()
    {
        h = gameObject.AddComponent<Highlighter>(); //On ajoute le component Highlighter qui se charge tout seul d'afficher l'outline.
    }

    // Use this for initialization
    void Start () {
        h.ConstantOffImmediate(); // On commence avec tous les objets portant ce script avec l'outliner désactivé.
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void launchOutliner() //On active l'outliner. Cette fonction est appelée par le script qui choisit à quel moment l'activer (ici, l'InteractionController)
    {
        // Fade in constant highlighting
        h.ConstantOn(Color.white); //Active l'outliner, attends une couleur.
    }

    public void stopOutliner() //On desactive l'outliner. Cette fonction est appelée par le script qui choisit à quel moment l'activer (ici, l'InteractionController)
    {
        // Turn off constant highlighting
        h.ConstantOffImmediate(); //Desactuve l'outliner.
    }

}