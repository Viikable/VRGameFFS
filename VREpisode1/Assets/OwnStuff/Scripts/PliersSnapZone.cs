using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PliersSnapZone : MonoBehaviour {
    VRTK_SnapDropZone PlierZone;
    VRTK_SnapDropZone PlierZoneBox;
    GameObject RightController;
    GameObject LeftController;

    void Awake () {
        PlierZone = GetComponentInChildren<VRTK_SnapDropZone>();
        RightController = GameObject.Find("RightController");
        LeftController = GameObject.Find("LeftController");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == gameObject
                || LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == gameObject)
        {
            if (other.CompareTag("JanitorBroom") && !other.GetComponentInParent<VRTK_InteractableObject>().IsGrabbed())
            {
                PlierZone.ForceSnap(other.gameObject);
                Debug.Log("forcesnap");
            }
        }
    }
}
