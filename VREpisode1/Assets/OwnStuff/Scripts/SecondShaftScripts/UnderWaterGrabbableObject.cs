﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[DisallowMultipleComponent]
public class UnderWaterGrabbableObject : MonoBehaviour {
    //These objects can be grabbed underwater
 
    protected bool damagedByWater;
    protected AudioSource DamagedSound;   
    protected GameObject GrabbableWater;

    [Tooltip("This detects if left hand is near touching an object which can be grabbed underwater")]
    protected static int lefthandPartsTouchingWaterObject;

    [Tooltip("This detects if right hand is near touching an object which can be grabbed underwater")]
    protected static int righthandPartsTouchingWaterObject;

    [Tooltip("This indicates whether water is currently grabbable for either controller or not")]
    protected static bool waterGrabbingNotAllowed;

    protected virtual void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();      
        GrabbableWater = GameObject.Find("SHAFTS/Water/GrabbableWater");
        lefthandPartsTouchingWaterObject = 0;
        righthandPartsTouchingWaterObject = 0;
        waterGrabbingNotAllowed = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GrabbableWater && !damagedByWater)
        {
            damagedByWater = true;
            if (DamagedSound != null)
            {
            DamagedSound.Play();        
            }
        }
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandPartsTouchingWaterObject += 1;                                 
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandPartsTouchingWaterObject += 1;             
            }
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandPartsTouchingWaterObject -= 1;
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandPartsTouchingWaterObject -= 1;              
            }
        }
    }

    public bool IsDamagedByWater()
    {
        return damagedByWater;
    }
    //checks whether waterGrabbing is allowed currently or not and which hand can grab water if any or both
    private void FixedUpdate()
    {
        //Debug.Log(lefthandTouchingWaterObject + "lefthandtouch");
        //Debug.Log(righthandTouchingWaterObject + "righthandtouch");
        if (lefthandPartsTouchingWaterObject > 0 && righthandPartsTouchingWaterObject > 0)
        {
            waterGrabbingNotAllowed = true;
            Debug.Log("WaterGrabNotAllowed");
        }
        else
        {
            waterGrabbingNotAllowed = false;
        }
        if (waterGrabbingNotAllowed)
        {
            GrabbableWater.GetComponent<ClimbInteractable>().enabled = false;
        }
        else
        {
            GrabbableWater.GetComponent<ClimbInteractable>().enabled = true;
        }
        //allows both if no hands are near objects, otherwise only one of the hands
        if (lefthandPartsTouchingWaterObject == 0 && righthandPartsTouchingWaterObject == 0)
        {
            //GrabbableWater.GetComponent<XRGrabInteractable>().allowedGrabControllers = XRGrabInteractable.AllowedController.Both;         
        }
        else if (lefthandPartsTouchingWaterObject >= 1 && righthandPartsTouchingWaterObject == 0)
        {
            //GrabbableWater.GetComponent<XRGrabInteractable>().allowedGrabControllers = XRGrabInteractable.AllowedController.RightOnly;
            //Debug.Log("Rightonly");
        }
        else if (righthandPartsTouchingWaterObject >= 1  && lefthandPartsTouchingWaterObject == 0)
        {
            //GrabbableWater.GetComponent<XRGrabInteractable>().allowedGrabControllers = XRGrabInteractable.AllowedController.LeftOnly;
            //Debug.Log("Leftonly");
        }
    }
}
