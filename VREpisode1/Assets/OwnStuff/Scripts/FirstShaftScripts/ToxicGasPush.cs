using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ToxicGasPush : MonoBehaviour {
    bool beingPushed;
    bool notEnded;
    Rigidbody pushedObject;
    public GameObject CameraRig;
    Rigidbody PlayerBody;

    private void Start()
    {
        beingPushed = false;
        notEnded = true;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == WaterMovement.head || other == WaterMovement.feet)
        {
            pushedObject = PlayerBody;
            beingPushed = true;
            Debug.Log("PlayerPush");
        }
        else
        {
            if (other.gameObject.GetComponentInParent<Rigidbody>() != null)
            {
                pushedObject = other.gameObject.GetComponentInParent<Rigidbody>();
                beingPushed = true;
                Debug.Log("ObjectPushParent");
            }
            else if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                pushedObject = other.gameObject.GetComponentInParent<Rigidbody>();
                beingPushed = true;
                Debug.Log("ObjectPushSelf");
            }
        }
    }
    private void FixedUpdate()
    {
        if (beingPushed)
        {          
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null || Game_Manager.instance.RightGrab.GetGrabbedObject() != null)
            {
                Game_Manager.instance.LeftGrab.ForceRelease();
                Game_Manager.instance.RightGrab.ForceRelease();
            }
            pushedObject.AddForce(new Vector3(0f, -20f, -500f), ForceMode.Impulse);
            beingPushed = false;
        }
        if (Time.time >= 0.5f)
        {
            PlayerBody = CameraRig.GetComponent<Rigidbody>();
        }
    }           
}
