using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OpenBoxUnSnapTrigger : MonoBehaviour
{
    VRTK_SnapDropZone OpenBoxSnap;
    GameObject Marker;
    VRTK_InteractGrab RightGrab;
    VRTK_InteractGrab LeftGrab;
    GameObject RightController;
    GameObject LeftController;

    Collider temp;

    bool grabLeft;
    bool grabRight;

    void Start()
    {
        OpenBoxSnap = GetComponent<VRTK_SnapDropZone>();
        Marker = GameObject.Find("Marker");

        RightController = GameObject.Find("RightController");

        LeftController = GameObject.Find("LeftController");

        RightGrab = RightController.GetComponent<VRTK_InteractGrab>();

        LeftGrab = LeftController.GetComponent<VRTK_InteractGrab>();

        grabLeft = false;
        grabRight = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        temp = other;
        if (other == Marker)
        {
            OpenBoxSnap.ForceSnap(Marker);
        }

        if (OpenBoxSnap.GetCurrentSnappedObject() != null && OpenBoxSnap.GetCurrentSnappedObject() ==
            Marker)
        {            
            if (other.transform.parent != null && other.transform.parent.name == "HandColliders" && other.transform.parent.transform.parent.name == "VRTK_LeftBasicHand")               
            {
                Debug.Log("UnsnapL");
                OpenBoxSnap.ForceUnsnap();
                LeftController.GetComponent<VRTK_InteractTouch>().ForceTouch(Marker);
                grabLeft = true;
            }
            else if (other.transform.parent != null && other.transform.parent.name == "HandColliders" && other.transform.parent.transform.parent.name == "VRTK_RightBasicHand")
            {
                Debug.Log("UnsnapR");
                OpenBoxSnap.ForceUnsnap();
                RightController.GetComponent<VRTK_InteractTouch>().ForceTouch(Marker);
                grabRight = true;
            }
        }
    }
    private void Update()
    {
        Debug.Log(temp.transform.parent.transform.parent.name);
        if (grabLeft && LeftGrab.GetGrabbedObject() == null)
        {
            LeftGrab.AttemptGrab();
        }
        else if (grabRight && RightGrab.GetGrabbedObject() == null)
        {
            RightGrab.AttemptGrab();
        }
        if (LeftGrab.GetGrabbedObject() == Marker || RightGrab.GetGrabbedObject() == Marker)
        {
            grabRight = false;
            grabLeft = false;
        }
    }
}