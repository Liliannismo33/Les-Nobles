using UnityEngine;
using Valve.VR.InteractionSystem;

/*
 * This class is attached to a door handle. The door handle is child of a door.
 */
public class DoorVR : MonoBehaviour
{
    private bool holdingHandle;
    private OVRGrabber interactionHand;
    private Vector3 grabPosition;
    private Vector3 handPosition;
    public float rotationSpeed = 1f;
    private Transform handle;
    public bool isLock;

    private void Start()
    {
        handle = transform.GetChild(0);
    }

    private void HandHoverUpdate()
    {
        if (!isLock)
        {
            if (interactionHand != null)
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, interactionHand.GetController()) > 0.55f && !holdingHandle)
                {
                    grabPosition = interactionHand.transform.position;
                    holdingHandle = true;
                }
                else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, interactionHand.GetController()) < 0.35f && holdingHandle)
                {
                    interactionHand = null;
                    holdingHandle = false;
                }
            }
        }        
    }

    void Update()
    {
        HandHoverUpdate();
        if (!isLock)
        {
            if (holdingHandle)
            {
                handPosition = interactionHand.transform.position;
                Vector3 currentForward = transform.forward;
                currentForward.y = 0f;
                currentForward.Normalize();

                Vector3 targetForward = handPosition - transform.position;
                targetForward.y = 0f;
                targetForward.Normalize();

                transform.forward = targetForward;


                /*Quaternion testRot = Quaternion.FromToRotation(currentForward, targetForward);
                transform.rotation = Quaternion.Lerp(transform.rotation, testRot, rotationSpeed * Time.deltaTime);*/
            }

            //if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, interactionHand.GetController()) > 0.55f)
            //{
            //    //Debug.Log(interactionHand.transform.position);
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionHand"))
        {
            interactionHand = other.GetComponent<OVRGrabber>();
        }
        if (other.CompareTag("Key"))
        {
            isLock = false;
            EventManager.s_Singleton.actualStepFirstEvent++;
            Destroy(other.gameObject, 0.05f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractionHand") && !holdingHandle)
        {
            interactionHand = null;
        }
    }
}