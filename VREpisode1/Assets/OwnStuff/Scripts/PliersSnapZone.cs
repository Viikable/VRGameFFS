using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PliersSnapZone : MonoBehaviour
{
    VRTK_SnapDropZone PlierZone;
    VRTK_SnapDropZone PlierZoneBox;
    GameObject RightController;
    GameObject LeftController;
    GameObject Broom;

    void Awake()
    {
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
                Broom = other.gameObject;
                PlierZone.ForceSnap(other.gameObject);
                foreach (MeshCollider col in other.gameObject.transform.parent.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = false;
                    Debug.Log("broomcollidersoff");
                }
                foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = true;
                    Debug.Log("plierbroomcolliders");
                }
                //other.gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
                //other.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
                Debug.Log("forcesnap");
            }
        }
    }
    private void Update()
    {
        if (PlierZone.GetCurrentSnappedObject() == null || !PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            foreach (MeshCollider col in gameObject.GetComponents<MeshCollider>())
            {
                col.enabled = false;
                Debug.Log("noplierbroomcolliders");
            }
            if (Broom != null)
            {
                foreach (MeshCollider col in Broom.transform.parent.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = true;
                    Debug.Log("broomcolliderson");
                }
            }
        }
    }
}
