﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToxicGasPush : MonoBehaviour {
    bool beingPushed;
    bool notEnded;
    Rigidbody pushedObject;
    public GameObject CameraRig;
    public static Rigidbody PlayerBody;

    private void Start()
    {
        beingPushed = false;
        notEnded = true;
        pushedObject = null;     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "BackpackCollider")
        {
            if (other == WaterMovement.head || other == WaterMovement.feet || other == WaterMovement.body)
            {
                pushedObject = PlayerBody;
                beingPushed = true;
                Debug.Log("PlayerPush");
            }
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                pushedObject = other.gameObject.GetComponent<Rigidbody>();
                beingPushed = true;
                Debug.Log("ObjectPushSelf");
            }
            else if (other.transform.parent != null && other.gameObject.GetComponentInParent<Rigidbody>() != null)
            {
                pushedObject = other.gameObject.GetComponentInParent<Rigidbody>();
                beingPushed = true;
                Debug.Log("ObjectPushParent");
            }
        }
    }
    private void FixedUpdate()
    {
        if (beingPushed && pushedObject != null)
        {
            Debug.Log("pushed");
            if (pushedObject == PlayerBody && (Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected != null || Game_Manager.instance.RightDirectInteractor.firstInteractableSelected != null))
            {
                Game_Manager.instance.LeftDirectInteractor.EndManualInteraction();
                Game_Manager.instance.RightDirectInteractor.EndManualInteraction();
            }
            if (pushedObject.mass == 100)
            {
                pushedObject.AddForce(new Vector3(0f, 0f, -200f), ForceMode.Impulse);
            }
            else
            {
                pushedObject.AddForce(new Vector3(0f, 0f, -100f), ForceMode.Impulse);
            }
            beingPushed = false;
        }
        if (Time.time >= 0.5f)
        {
            PlayerBody = CameraRig.GetComponent<Rigidbody>();
        }
    }           
}
