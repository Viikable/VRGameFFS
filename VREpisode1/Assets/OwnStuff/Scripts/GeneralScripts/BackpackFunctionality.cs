using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BackpackFunctionality : MonoBehaviour
{

    public BoxCollider backpack;
    VRTK_SnapDropZone backZone;
    GameObject previouslyGrabbed;
    GameObject backpackObject;
    public bool backpackFull;
    GameObject LeftHandColliders;
    GameObject RightHandColliders;
    public bool lefthandEntered;
    public bool righthandEntered;
    public AudioSource toBackpackSound;
    public AudioSource fromBackpackSound;


    void Start()
    {
        LeftHandColliders = VRTK_DeviceFinder.GetControllerLeftHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        RightHandColliders = VRTK_DeviceFinder.GetControllerRightHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        backpack = gameObject.AddComponent<BoxCollider>();
        backpack.size = new Vector3(2.74264f, 4.065854f, 0.6248869f);
        backpack.center = new Vector3(0.06899939f, -0.2205359f, -0.1689534f);
        backpack.isTrigger = true;
        backZone = gameObject.GetComponent<VRTK_SnapDropZone>();
        backpackFull = false;
        lefthandEntered = false;
        righthandEntered = false;
    }
       
    private void FixedUpdate()
    {       
        if (backZone.GetCurrentSnappedObject() != null && !backpackFull)
        {
            toBackpackSound.Play();
            backpackFull = true;
        }
        else if (backZone.GetCurrentSnappedObject() == null && backpackFull)
        {
            backpackFull = false;
            fromBackpackSound.Play();
            backZone.GetComponent<Collider>().enabled = true;
        }
        if (!backpackFull)
        {
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>() != null)
            {               
                if (!Game_Manager.instance.LeftGrab.GetGrabbedObject().CompareTag("PermanentHaptics"))
                {
                    Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>().enabled = false;
                }
            }
            else if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>() != null)
            {
                if (!Game_Manager.instance.RightGrab.GetGrabbedObject().CompareTag("PermanentHaptics"))
                {
                    Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>().enabled = false;                   
                }
            }
        }
        // this sets the haptics on ONLY when snapped to backpack
        if (backZone.GetCurrentSnappedObject() != null && backZone.GetCurrentSnappedObject().GetComponent<VRTK_InteractHaptics>() != null && backpackFull)
        {
            backZone.GetCurrentSnappedObject().GetComponent<VRTK_InteractHaptics>().enabled = true;
            backZone.GetComponent<Collider>().enabled = false;
        }       
    }
}


