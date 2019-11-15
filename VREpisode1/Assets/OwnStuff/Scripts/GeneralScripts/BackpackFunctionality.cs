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
    public GameObject LeftHandColliders;
    public GameObject RightHandColliders;
    public bool lefthandEntered;
    public bool righthandEntered;
    public AudioSource toBackpackSound;


    void Start()
    {
        LeftHandColliders = VRTK_DeviceFinder.GetControllerLeftHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        RightHandColliders = VRTK_DeviceFinder.GetControllerRightHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        backpack = gameObject.AddComponent<BoxCollider>();
        backpack.size = new Vector3(2.7426398f, 4.8061069f, 1.2186796f);
        backpack.center = new Vector3(0.06898964f, -0.01245906f, -0.1619698f);
        backpack.isTrigger = true;
        backZone = gameObject.GetComponent<VRTK_SnapDropZone>();
        backpackFull = false;
        lefthandEntered = false;
        righthandEntered = false;
    }
    

    private void OnTriggerEnter(Collider other)  //in order to snap objects to backpack slot if player stops holding the grabButton while in the trigger zone
    {
        

        if (other.gameObject.name == "Palm" || other.gameObject.name == "Thumb" || other.gameObject.name == "Index"
            || other.gameObject.name == "Middle" || other.gameObject.name == "Ring" || other.gameObject.name == "Pinky")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandEntered = true;
                Debug.Log("lefthandEntered");

            }
        }
        if (other.gameObject.name == "Palm" || other.gameObject.name == "Thumb" || other.gameObject.name == "Index"
            || other.gameObject.name == "Middle" || other.gameObject.name == "Ring" || other.gameObject.name == "Pinky")
        {
            if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandEntered = true;
                Debug.Log("righthandEntered");
            }
        }
       
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Palm" || other.gameObject.name == "Thumb" || other.gameObject.name == "Index"
            || other.gameObject.name == "Middle" || other.gameObject.name == "Ring" || other.gameObject.name == "Pinky")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandEntered = false;
            }
        }
        if (other.gameObject.name == "Palm" || other.gameObject.name == "Thumb" || other.gameObject.name == "Index"
             || other.gameObject.name == "Middle" || other.gameObject.name == "Ring" || other.gameObject.name == "Pinky")
        {
            if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandEntered = false;
            }
        }      
    }
    private void FixedUpdate()
    {
        if (lefthandEntered && !Game_Manager.instance.LeftGrab.IsGrabButtonPressed() && !backpackFull)
        {
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null)
            {               
                backZone.ForceSnap(Game_Manager.instance.LeftGrab.GetGrabbedObject());
                backpackFull = true;
                toBackpackSound.Play();             
            }
        }
        else if (righthandEntered && !Game_Manager.instance.RightGrab.IsGrabButtonPressed() && !backpackFull)
        {

            if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null)
            {                
                backZone.ForceSnap(Game_Manager.instance.RightGrab.GetGrabbedObject());
                backpackFull = true;
                toBackpackSound.Play();              
            }
        }
        else if (backZone.GetCurrentSnappedObject() == null && backpackFull)
        {
            backpackFull = false;
            toBackpackSound.Play();           
        }
        if (!backpackFull)
        {
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>() != null)
            {
                Debug.Log("leftnovib");
                Game_Manager.instance.LeftGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>().enabled = false;
            }
            else if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>() != null)
            {
                Game_Manager.instance.RightGrab.GetGrabbedObject().GetComponent<VRTK_InteractHaptics>().enabled = false;
                Debug.Log("rightnovib");
            }
        }
        // this sets the haptics on ONLY when snapped to backpack
        if (backZone.GetCurrentSnappedObject() != null && backZone.GetCurrentSnappedObject().GetComponent<VRTK_InteractHaptics>() != null)
        {
            backZone.GetCurrentSnappedObject().GetComponent<VRTK_InteractHaptics>().enabled = true;
        }       
    }
}


