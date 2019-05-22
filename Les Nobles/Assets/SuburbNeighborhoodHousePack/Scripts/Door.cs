using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    //private float distance;
    //private GameObject player;
    //private Ray ray;
    //public float raycastDistance;
    //private GameObject getTarget;
    private bool opened;

    void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");
		opened = false;
	}

	void Update () {

        InteractionController.s_Singleton.getTarget = InteractionController.s_Singleton.ReturnSpottedObject();

        if (opened == false)
		{
            //distance = Vector3.Distance(transform.position, player.transform.position);
            //ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
            //RaycastHit hit;
            //Debug.Log("Dans la porte pour ouvrir");
            if (OVRInput.GetDown(OVRInput.Button.One) /*&& distance < 2*/ && InteractionController.s_Singleton.getTarget.CompareTag("Door")/*Physics.Raycast (ray, out hit) && hit.collider.gameObject.tag == "Door"*/) {
                InteractionController.s_Singleton.getTarget.GetComponent<Animation>().Play ("DoorOpen");
				opened = true;
                //Debug.Log("La porte est ouverte");
			}
		}
		else
		{
            //distance = Vector3.Distance(transform.position, player.transform.position);
            //ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
            //RaycastHit hit;
            //Debug.Log("Dans la porte pour fermer");
            if (OVRInput.GetDown(OVRInput.Button.One) /*&& distance < 2 */&& InteractionController.s_Singleton.getTarget.CompareTag("Door")/*Physics.Raycast (ray, out hit) && hit.collider.gameObject.tag == "Door"*/) {
                InteractionController.s_Singleton.getTarget.GetComponent<Animation> ().Play ("DoorClose");
				opened = false;
                //Debug.Log("La porte est fermée");
            }
		}
	}

    /*private GameObject ReturnSpottedObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
    */
}
