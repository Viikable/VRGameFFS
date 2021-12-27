using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BackpackFunctionality : MonoBehaviour
{

    public BoxCollider backpack;  
    XRSocketInteractor backZone;
    GameObject previouslyGrabbed;
    GameObject backpackObject;
    public bool backpackFull;
    GameObject LeftHandColliders;
    GameObject RightHandColliders;
    public bool lefthandEntered;
    public bool righthandEntered;
    public AudioSource toBackpackSound;
    public AudioSource fromBackpackSound;
    bool notDisabled;

    void Start()
    {
        //find out what to get here
        //LeftHandColliders = VRTK_DeviceFinder.GetControllerLeftHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        //RightHandColliders = VRTK_DeviceFinder.GetControllerRightHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        backpack = gameObject.AddComponent<BoxCollider>();
        backpack.size = new Vector3(2.303633f, 2.189791f, 0.4338804f);
        backpack.center = new Vector3(0.02300131f, -0.2983266f, -0.05426104f);
        backpack.isTrigger = true;          
        backZone = gameObject.GetComponent<XRSocketInteractor>();
        backpackFull = false;
        lefthandEntered = false;
        righthandEntered = false;
        notDisabled = true;
    }

    private void Update()
    {
        if (backZone.firstInteractableSelected != null && !backpackFull)
        {
            toBackpackSound.Play();
            backpackFull = true;
        }
        else if (backZone.firstInteractableSelected == null && backpackFull)
        {
            //if (Game_Manager.instance.LeftGrab.firstInteractableSelected.Equals(null) && Game_Manager.instance.RightGrab.firstInteractableSelected.Equals(null))
            //{
            notDisabled = true;
            backpackFull = false;
            fromBackpackSound.Play();
            //backpack.enabled = true;         
            //}
            //else if (Game_Manager.instance.LeftGrab.firstInteractableSelected != null && Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<PackableObject>() == null)
            //{
            //    backpackFull = false;
            //    fromBackpackSound.Play();
            //    backZone.GetComponent<Collider>().enabled = true;
            //}
            //else if (Game_Manager.instance.RightGrab.firstInteractableSelected != null && Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<PackableObject>() == null)
            //{
            //    backpackFull = false;
            //    fromBackpackSound.Play();
            //    backZone.GetComponent<Collider>().enabled = true;
            //}
        }
        if (!backpackFull)
        {
            //send haptic impulse to hand another way through openXR
        //    if (Game_Manager.instance.LeftGrab.firstInteractableSelected != null && Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>() != null)
        //    {
        //        if (!Game_Manager.instance.LeftGrab.GetGrabbedObject().CompareTag("PermanentHaptics"))
        //        {
        //            Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>().enabled = false;
        //        }
        //    }
        //    else if (Game_Manager.instance.RightGrab.firstInteractableSelected != null && Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>() != null)
        //    {
        //        if (!Game_Manager.instance.RightGrab.GetGrabbedObject().CompareTag("PermanentHaptics"))
        //        {
        //            Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>().enabled = false;
        //        }
        //    }
        //}
        //// this sets the haptics on ONLY when snapped to backpack
        //if (backZone.firstInteractableSelected != null && backZone.firstInteractableSelected.transform.gameObject.GetComponent<VRTK_InteractHaptics>() != null && backpackFull && notDisabled)
        //{
        //    //backpack.enabled = false;     
        //    notDisabled = false;
        //    backZone.firstInteractableSelected.transform.gameObject.GetComponent<VRTK_InteractHaptics>().enabled = true;  //could postpone this?
        //    foreach (Collider col in backZone.firstInteractableSelected.transform.gameObject.GetComponentsInChildren<Collider>())
        //    {
        //        Physics.IgnoreCollision(WaterMovement.feet, col);
        //        Physics.IgnoreCollision(WaterMovement.body, col);
        //        Physics.IgnoreCollision(WaterMovement.head, col);
        //        Debug.Log("ignoredcol");
        //    }
        //}
        //to make the box collider not collide with everything
        //if (Time.time >= 0.5f && notDisabled)
        //{
        //    notDisabled = false;
        //    int i = 0;
        //    foreach (Collider col in FindObjectsOfType<Collider>())
        //    {
        //        if (col.gameObject.GetComponent<PackableObject>() == null)
        //        {
        //            if (col.gameObject.transform.parent != null && col.gameObject.GetComponentInParent<PackableObject>() == null)
        //            {
        //                if (col.gameObject.transform.parent.parent != null && col.gameObject.transform.parent.GetComponentInParent<PackableObject>() == null)
        //                {
        //                    Physics.IgnoreCollision(col, backpack);
        //                    Debug.Log(col.gameObject.name + i);
        //                    i++;
        //                }
        //                else if (col.gameObject.transform.parent.parent == null)
        //                {
        //                    Physics.IgnoreCollision(col, backpack);
        //                    Debug.Log(col.gameObject.name + i);
        //                    i++;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //            else if (col.gameObject.transform.parent == null)
        //            {
        //                Physics.IgnoreCollision(col, backpack);
        //                Debug.Log(col.gameObject.name + i);
        //                i++;
        //            } 
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        }
    }
}


