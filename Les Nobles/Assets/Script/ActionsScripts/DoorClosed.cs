using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosed : MonoBehaviour {

    //private GameObject player;
    public GameObject key;
    private Ray ray;
    private bool opened;
    public bool isLock;
    private int stepState;

    void Start()
    {
        stepState = EventManager.s_Singleton.actualStepFirstEvent; //synchronisation entre état actuel de l'événement ici et le même dans EventManager
        //player = GameObject.FindGameObjectWithTag ("Player");
        opened = false;
    }

    void Update()
    {

        if (opened == false)
        {
            //distance = Vector3.Distance(transform.position, player.transform.position);
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            //Debug.Log("Dans la porte pour ouvrir");

            if (isLock == false)
            {
                if (OVRInput.GetDown(OVRInput.Button.One) /*&& distance < 2*/ && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Door")
                {
                    gameObject.GetComponent<Animation>().Play("DoorOpen");
                    opened = true;
                    //Debug.Log("La porte est ouverte");
                }
            }
        }
        else
        {
            //distance = Vector3.Distance(transform.position, player.transform.position);
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            //Debug.Log("Dans la porte pour fermer");

            if (isLock == false)
            {
                if (OVRInput.GetDown(OVRInput.Button.One) /*&& distance < 2 */&& Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Door")
                {
                    gameObject.GetComponent<Animation>().Play("DoorClose");
                    opened = false;
                    //Debug.Log("La porte est fermée");
                }
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == ("Key"))
        {
            isLock = false;
            Debug.Log("La porte est déverouillée");
            EventManager.s_Singleton.actualStepFirstEvent++;
            Debug.Log(EventManager.s_Singleton.actualStepFirstEvent);
            Destroy(other.gameObject);
        }
    }
}