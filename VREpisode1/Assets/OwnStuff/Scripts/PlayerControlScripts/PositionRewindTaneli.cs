using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR;

public class PositionRewindTaneli : MonoBehaviour
{
    //rewinds player rig to last non-colliding position                                                                 //Taneli Nyyssönen

    //public ActionBasedController left;     
    public XRRig xrRig;
    public GameObject Headset;
    [Tooltip("How far to push")]
    public float pushBackDistance = 0.25f;
    [Tooltip("How often checking the last good positions")]
    public float waitTime = 0.25f;
    //[Tooltip("In case want a delay before the rewind occurrs")]
    //public float delay = 0.1f;

    Vector3 resetVector;
    Vector3 moveOffset;

    bool colliding = false;
    
    Vector3 lastGoodPlayAreaPos;
    Vector3 lastGoodHeadsetPos;

    bool waitedSomeTime;

    private void Start()
    {      
        lastGoodPlayAreaPos = Vector3.zero;
        lastGoodHeadsetPos = Vector3.zero;
        waitedSomeTime = true;
        //XRSettings.useOcclusionMesh = false;
    }

    private void FixedUpdate()
    {
        //XRSettings.useOcclusionMesh = false;
        
        //Debug.Log(XRSettings.useOcclusionMesh);
        if (waitedSomeTime && !colliding)
        {
            SetLastGoodPositions();
        }
    }

    private void SetLastGoodPositions()
    {
        lastGoodPlayAreaPos = xrRig.transform.position;
        lastGoodHeadsetPos = Headset.transform.position;
        waitedSomeTime = false;
        StartCoroutine(WaitAMinute());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Wall") && !colliding)
        {
            colliding = true;
            resetVector = lastGoodHeadsetPos - Headset.transform.position;
            moveOffset = resetVector.normalized * pushBackDistance;
            xrRig.transform.position += resetVector + moveOffset;
            Debug.Log("reset");
            //StartCoroutine(DelayedRewind(delay));         
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            colliding = true;
            resetVector = lastGoodHeadsetPos - Headset.transform.position;
            moveOffset = resetVector.normalized * pushBackDistance;
            xrRig.transform.position += resetVector + moveOffset;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            colliding = false;
        }
    }

    IEnumerator WaitAMinute()
    {
        yield return new WaitForSeconds(waitTime);
        waitedSomeTime = true;
    }

    IEnumerator DelayedRewind(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (colliding)
        {
           
        }
    }

    public void TestMethod()
    {
        //Debug.Log("TestSocketHover");
        //left.hapticDeviceAction.action.Enable();
        //left.SendHapticImpulse(1f, 3f);
        //Debug.Log(left.hapticDeviceAction.reference.ToString());
    }
}
