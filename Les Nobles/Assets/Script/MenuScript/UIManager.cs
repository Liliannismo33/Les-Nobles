using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject menuDoor;
    public Image UIMenu;
    public GameObject canvasMenu;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && InteractionController.s_Singleton.getTarget.CompareTag("DoorMenu"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        canvasMenu.SetActive(!canvasMenu.activeSelf);
        if (canvasMenu.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("Jeu en pause");
        }
        else if (!canvasMenu.activeSelf)
        {
            Time.timeScale = 1;
            Debug.Log("Jeu plus en pause");
        }
    }

    public void OnClicSortir()
    {
        Application.Quit();
    }
}
