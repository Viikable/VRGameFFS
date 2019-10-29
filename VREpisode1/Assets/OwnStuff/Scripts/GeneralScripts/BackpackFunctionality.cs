using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BackpackFunctionality : MonoBehaviour {

    public BoxCollider backpack;
    VRTK_SnapDropZone backZone;
    GameObject previouslyGrabbed;
    GameObject backpackObject;
    public bool backpackFull;
    public GameObject LeftHandColliders;
    public GameObject RightHandColliders;

    void Start()
    {
        LeftHandColliders = VRTK_DeviceFinder.GetControllerLeftHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        RightHandColliders = VRTK_DeviceFinder.GetControllerRightHand().gameObject.transform.GetChild(0).GetChild(2).gameObject;
        backpack = gameObject.AddComponent<BoxCollider>();
        backpack.size = new Vector3(0.4651775f, 0.2086213f, 0.1626915f);
        backpack.center = new Vector3(-0.004957672f, -0.03318618f, -0.07300865f);
        backpack.isTrigger = true;
        backZone = gameObject.GetComponent<VRTK_SnapDropZone>();
        backpackFull = false;
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
        if (!backpackFull)
        {
            if (other.transform.parent == LeftHandColliders /*&& !Game_Manager.instance.LeftGrab.IsGrabButtonPressed()*/)
            {
                Debug.Log("lefthandentered");
                if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null)
                {                
                    backZone.ForceSnap(Game_Manager.instance.LeftGrab.GetGrabbedObject().gameObject);
                    //turn off colliders to not hit player while in backpack
                    if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
                    {
                    backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = false;
                    }
                    if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
                    {
                        foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
                        {
                            col.enabled = false;
                        }
                    }                    
                    backpackFull = true;
                    backpackObject = backZone.GetCurrentSnappedObject().gameObject;
                }
            }
            else if (other.transform.parent == RightHandColliders /*&& !Game_Manager.instance.RightGrab.IsGrabButtonPressed()*/)
            {
                if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null)
                {
                    backZone.ForceSnap(Game_Manager.instance.RightGrab.GetGrabbedObject().gameObject);

                    if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
                    {
                        backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = false;
                    }
                    if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
                    {
                        foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
                        {
                            col.enabled = false;
                        }
                    }
                    backpackFull = true;
                    backpackObject = backZone.GetCurrentSnappedObject().gameObject;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {         
        if (backpackFull)
        {
            if (other.transform.parent == LeftHandColliders && Game_Manager.instance.LeftGrab.IsGrabButtonPressed())
            {
                Debug.Log("left hand attempts to take back");
                if (Game_Manager.instance.LeftGrab.GetGrabbedObject() == null)
                {
                    backZone.ForceUnsnap();

                    if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
                    {
                        backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = true;
                    }
                    if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
                    {
                        foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
                        {
                            col.enabled = true;
                        }
                    }
                    backpackObject.transform.position = HandsLighting.LeftHandModel.transform.position;
                    backpackObject.transform.rotation = HandsLighting.LeftHandModel.transform.rotation;
                    while (Game_Manager.instance.LeftGrab.GetGrabbedObject() == null)
                    {
                        Game_Manager.instance.LeftGrab.AttemptGrab();
                    }

                    backpackFull = false;
                }
            }
            else if (other.transform.parent == RightHandColliders && Game_Manager.instance.RightGrab.IsGrabButtonPressed())
            {
                if (Game_Manager.instance.RightGrab.GetGrabbedObject() == null)
                {
                    backZone.ForceUnsnap();

                    if (backZone.GetCurrentSnappedObject().GetComponent<Collider>() != null)
                    {
                        backZone.GetCurrentSnappedObject().GetComponent<Collider>().enabled = true;
                    }
                    if (backZone.GetCurrentSnappedObject().GetComponentInChildren<Collider>() != null)
                    {
                        foreach (Collider col in backZone.GetCurrentSnappedObject().GetComponentsInChildren<Collider>())
                        {
                            col.enabled = true;
                        }
                    }
                    backpackObject.transform.position = HandsLighting.RightHandModel.transform.position;
                    backpackObject.transform.rotation = HandsLighting.RightHandModel.transform.rotation;
                    while (Game_Manager.instance.RightGrab.GetGrabbedObject() == null)
                    {
                    Game_Manager.instance.RightGrab.AttemptGrab();
                    }
                    backpackFull = false;
                }
            }
        }
    }   
}
