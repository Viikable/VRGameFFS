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
    public static int lefthandPartsTouchingWaterObject;

    [Tooltip("This detects if right hand is near touching an object which can be grabbed underwater")]
    public static int righthandPartsTouchingWaterObject;

    [Tooltip("This indicates whether water is currently grabbable for either controller or not")]
    public static bool waterGrabbingNotAllowed;

    void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
        LanternLight = GetComponent<Light>();
        GrabbableWater = GameObject.Find("Water/GrabbableWater");
        lefthandPartsTouchingWaterObject = 0;
        righthandPartsTouchingWaterObject = 0;
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
                lefthandPartsTouchingWaterObject += 1;                                 
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandPartsTouchingWaterObject += 1;             
            }
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
    //    {
    //        if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
    //        {
    //            lefthandPartsTouchingWaterObject = true;
    //        }
    //        else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
    //        {
    //            righthandPartsTouchingWaterObject = true;
    //        }
    //    }
    //}
    private void OnTriggerExit(Collider other)
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
            GrabbableWater.GetComponent<VRTK_InteractableObject>().enabled = false;
        }
        else
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().enabled = true;
        }
        //allows both if no hands are near objects, otherwise only one of the hands
        if (lefthandPartsTouchingWaterObject == 0 && righthandPartsTouchingWaterObject == 0)
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().allowedGrabControllers = VRTK_InteractableObject.AllowedController.Both;
        }
        else if (lefthandPartsTouchingWaterObject >= 5 && righthandPartsTouchingWaterObject == 0)
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().allowedGrabControllers = VRTK_InteractableObject.AllowedController.RightOnly;
            Debug.Log("Rightonly");
        }
        else if (righthandPartsTouchingWaterObject >= 5  && lefthandPartsTouchingWaterObject == 0)
        {
            GrabbableWater.GetComponent<VRTK_InteractableObject>().allowedGrabControllers = VRTK_InteractableObject.AllowedController.LeftOnly;
            Debug.Log("Leftonly");
        }
    }
}
