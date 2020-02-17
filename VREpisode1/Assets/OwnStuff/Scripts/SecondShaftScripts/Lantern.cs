using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Lantern : MonoBehaviour {

    public bool damagedByWater;
    public AudioSource DamagedSound;
    public Light LanternLight;
    public GameObject GrabbableWater;

    [Tooltip("This detects if left hand is near touching an object which can be grabbed underwater")]
    public static bool lefthandTouchingWaterObject;

    [Tooltip("This detects if right hand is near touching an object which can be grabbed underwater")]
    public static bool righthandTouchingWaterObject;

    [Tooltip("This indicates whether water is currently grabbable for either controller or not")]
    public static bool waterGrabbingNotAllowed;

    void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
        LanternLight = GetComponent<Light>();
        GrabbableWater = GameObject.Find("Water/GrabbableWater");
        lefthandTouchingWaterObject = false;
        righthandTouchingWaterObject = false;
        waterGrabbingNotAllowed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && !damagedByWater)
        {
            damagedByWater = true;
            DamagedSound.Play();
            LanternLight.enabled = false;
        }
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandTouchingWaterObject = true;                                 
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandTouchingWaterObject = true;             
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandTouchingWaterObject = true;
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandTouchingWaterObject = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandTouchingWaterObject = false;
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandTouchingWaterObject = false;              
            }
        }
    }
    //checks whether waterGrabbing is allowed currently or not and which hand can grab water if any or both
    private void Update()
    {
        //Debug.Log(lefthandTouchingWaterObject + "lefthandtouch");
        //Debug.Log(righthandTouchingWaterObject + "righthandtouch");
        if (lefthandTouchingWaterObject && righthandTouchingWaterObject)
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
            GrabbableWater.GetComponent<VRTK_InteractableObject>().enabled = false;
        }
        else
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().enabled = true;
        }
        //allows both if no hands are near objects, otherwise only one of the hands
        if (!lefthandTouchingWaterObject && !righthandTouchingWaterObject)
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().allowedGrabControllers = VRTK_InteractableObject.AllowedController.Both;
        }
        else if (lefthandTouchingWaterObject && !righthandTouchingWaterObject)
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().allowedGrabControllers = VRTK_InteractableObject.AllowedController.RightOnly;
        }
        else if (righthandTouchingWaterObject && !lefthandTouchingWaterObject)
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().allowedGrabControllers = VRTK_InteractableObject.AllowedController.LeftOnly;
        }
    }
}
