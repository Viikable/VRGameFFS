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
        backpack.size = new Vector3(0.4651775f, 0.3286213f, 0.2226915f);
        backpack.center = new Vector3(-0.004957672f, -0.03318618f, -0.07300865f);
        backpack.isTrigger = true;
        backZone = gameObject.GetComponent<VRTK_SnapDropZone>();
        backpackFull = false;
        lefthandEntered = false;
        righthandEntered = false;
    }
    //private void OnTriggerEnter(Collider other)  //checking what object was grabbed if any when hand enters the backpack trigger collider
    //{
    //    if (other.transform.parent.name == "HandColliders" && Game_Manager.instance.LeftGrab.GetGrabbedObject() != null)
    //    {
    //        previouslyGrabbed = Game_Manager.instance.LeftGrab.GetGrabbedObject().gameObject;
    //    }
    //    else if (other.transform.parent.name == "HandColliders" && Game_Manager.instance.RightGrab.GetGrabbedObject() != null)
    //    {
    //        previouslyGrabbed = Game_Manager.instance.RightGrab.GetGrabbedObject().gameObject;
    //    }
    //}

    private void OnTriggerEnter(Collider other)  //in order to snap objects to backpack slot if player stops holding the grabButton while in the trigger zone
    {
        //    if (!backpackFull)
        //    {
        //        Debug.Log("somethingentered");
        //        if (other.GetComponent<VRTK_InteractableObject>() != null || other.transform.parent.GetComponent<VRTK_InteractableObject>() != null) /*&& !Game_Manager.instance.LeftGrab.IsGrabButtonPressed()*/
        //        {
        //            Debug.Log("interactable Object entered");
        //            //if ((Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject() == other.gameObject) 
        //            //    || (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject() == other.gameObject))
        //            //{                
        //            if (other.gameObject.GetComponent<Rigidbody>() != null)
        //            {
        //                other.gameObject.GetComponent<Rigidbody>().Sleep();
        //            }
        //            else if (other.transform.parent.GetComponent<Rigidbody>() != null)
        //            {
        //                other.transform.parent.GetComponent<Rigidbody>().Sleep();
        //            }
        //            backZone.ForceSnap(other.gameObject);
        //            Debug.Log("interactable tries to snap");
        //            //turn off colliders to not hit player while in backpack
        //            if (backZone.GetCurrentSnappedObject() != null && backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
        //            {
        //                backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = false;
        //            }
        //            if (backZone.GetCurrentSnappedObject() != null && backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
        //            {
        //                foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
        //                {
        //                    col.enabled = false;
        //                }
        //            }
        //            backpackFull = true;
        //            if (backZone.GetCurrentSnappedObject() != null)
        //            {
        //                backpackObject = backZone.GetCurrentSnappedObject().gameObject;
        //            }
        //        }
        //    }

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
        //    else if (other.transform.parent == RightHandColliders /*&& !Game_Manager.instance.RightGrab.IsGrabButtonPressed()*/)
        //    {
        //        if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject() == other.gameObject)
        //        {
        //            backZone.ForceSnap(Game_Manager.instance.RightGrab.GetGrabbedObject().gameObject);

        //            if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
        //            {
        //                backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = false;
        //            }
        //            if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
        //            {
        //                foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
        //                {
        //                    col.enabled = false;
        //                }
        //            }
        //            backpackFull = true;
        //            backpackObject = backZone.GetCurrentSnappedObject().gameObject;
        //        }
        //    }
    }
    //}
    //private void OnTriggerStay(Collider other)
    //{         
    //    if (backpackFull)
    //    {
    //        if (lefthandEntered && Game_Manager.instance.LeftGrab.IsGrabButtonPressed())
    //        {
    //            Debug.Log("left hand attempts to take back");
    //            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() == null)
    //            {
    //                backZone.ForceUnsnap();
    //                if (backZone.GetCurrentSnappedObject() != null)
    //                {

    //                    if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
    //                    {
    //                        backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = true;
    //                    }
    //                    if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
    //                    {
    //                        foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
    //                        {
    //                            col.enabled = true;
    //                        }
    //                    }
    //                }
    //                backpackObject.transform.position = HandsLighting.LeftHandModel.transform.position;
    //                backpackObject.transform.rotation = HandsLighting.LeftHandModel.transform.rotation;
    //                //while (Game_Manager.instance.LeftGrab.GetGrabbedObject() == null)
    //                //{
    //                    Game_Manager.instance.LeftGrab.AttemptGrab();
    //                //}
    //                backpackFull = false;
    //            }
    //        }
    //        else if (righthandEntered && Game_Manager.instance.RightGrab.IsGrabButtonPressed())
    //        {
    //            Debug.Log("right hand attempts to take back");
    //            if (Game_Manager.instance.RightGrab.GetGrabbedObject() == null)
    //            {
    //                backZone.ForceUnsnap();
    //                if (backZone.GetCurrentSnappedObject() != null)
    //                {
    //                if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
    //                {
    //                    backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = true;
    //                }
    //                    if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
    //                    {
    //                        foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
    //                        {
    //                            col.enabled = true;
    //                        }

    //                    }
    //                }
    //                backpackObject.transform.position = HandsLighting.RightHandModel.transform.position;
    //                backpackObject.transform.rotation = HandsLighting.RightHandModel.transform.rotation;
    //                //while (Game_Manager.instance.RightGrab.GetGrabbedObject() == null)
    //                //{
    //                Game_Manager.instance.RightGrab.AttemptGrab();
    //                //}
    //                backpackFull = false;
    //            }
    //        }
    //    }
    //}
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
        //if (other.GetComponent<VRTK_InteractableObject>() != null || other.transform.parent.GetComponent<VRTK_InteractableObject>() != null)
        //{
        //    if (other.gameObject.GetComponent<Rigidbody>() != null)
        //    {
        //        other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //    }
        //    else if (other.transform.parent.GetComponent<Rigidbody>() != null)
        //    {
        //        other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        //    }
        //}
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
        Debug.Log(Game_Manager.instance.LeftGrab.GetGrabbedObject());
    }
}


