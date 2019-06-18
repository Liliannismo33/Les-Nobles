using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    //private float distance;
    //private GameObject player;
    //private Ray ray;
    //public float raycastDistance;
    //private GameObject getTarget;
    private Animation myAnims;
    private bool opened;
    public AudioClip openingDoor;
    private bool canBeUsed = false;


    void Start () {
        //player = GameObject.FindGameObjectWithTag ("Player");
        myAnims = GetComponent<Animation>();
		opened = false;
	}

	void Update () {

        if (!opened)
		{
            //distance = Vector3.Distance(transform.position, player.transform.position);
            //ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
            //RaycastHit hit;
            //Debug.Log("Dans la porte pour ouvrir");
            if (OVRInput.GetDown(OVRInput.Button.Two) && canBeUsed)/*Physics.Raycast (ray, out hit) && hit.collider.gameObject.tag == "Door"*/ {
                AudioManager.s_Singleton.PlayClip(openingDoor);
                myAnims.Play ("DoorOpen");
				opened = true;
                //Debug.Log("La porte est ouverte");
			}
		}
		/*else
		{
            //distance = Vector3.Distance(transform.position, player.transform.position);
            //ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
            //RaycastHit hit;
            //Debug.Log("Dans la porte pour fermer");
            if (OVRInput.GetDown(OVRInput.Button.Two) && canBeUsed)/*Physics.Raycast (ray, out hit) && hit.collider.gameObject.tag == "Door" {
                AudioManager.s_Singleton.PlayClip(openingDoor);
                myAnims.Play("DoorClose");
				opened = false;
                //Debug.Log("La porte est fermée");
            }
		}*/

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractionHand"))
        {
            canBeUsed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionHand"))
        {
            canBeUsed = true;
        }
    }
}
