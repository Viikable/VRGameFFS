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
        backpack.size = new Vector3(2.303633f, 2.189791f, 0.4338804f);
        backpack.center = new Vector3(0.02300131f, -0.2983266f, -0.05426104f);
        backpack.isTrigger = true;
        backZone = gameObject.GetComponent<VRTK_SnapDropZone>();
        backpackFull = false;
        lefthandEntered = false;
        righthandEntered = false;
    }
       
    private void Update()
    {       
        if (backZone.GetCurrentSnappedObject() != null && !backpackFull)
        {
            toBackpackSound.Play();
            backpackFull = true;
        }
        else if (backZone.GetCurrentSnappedObject() == null && backpackFull)
        {
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() == null && Game_Manager.instance.RightGrab.GetGrabbedObject() == null)
            {
            backpackFull = false;
            fromBackpackSound.Play();
            backZone.GetComponent<Collider>().enabled = true;
            }
            else if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<PackableObject>() == null)
            {
                backpackFull = false;
                fromBackpackSound.Play();
                backZone.GetComponent<Collider>().enabled = true;
            }
            else if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<PackableObject>() == null)
            {
                backpackFull = false;
                fromBackpackSound.Play();
                backZone.GetComponent<Collider>().enabled = true;
            }
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
            backZone.GetComponent<Collider>().enabled = false;
            backZone.GetCurrentSnappedObject().GetComponent<VRTK_InteractHaptics>().enabled = true;  //could postpone this?
        }       
    }
}


