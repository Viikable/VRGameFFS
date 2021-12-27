using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PliersSnapZone : MonoBehaviour
{
    XRSocketInteractor PlierZone;
    XRSocketInteractor PlierZoneBox;
    GameObject RightController;
    GameObject LeftController;
    GameObject Broom;
    Vector3 ProperMass;
    Rigidbody PliersBody;
    public static bool beingReleased;
    public Collider BroomCollider1;
    public Collider BroomCollider2;
    public Collider BroomCollider3;
    public Collider BroomCollider4;
    public Collider BroomCollider5;
    public Collider BroomCollider6;
    public Collider BroomCollider7;
    public Collider BroomCollider8;

    protected void Awake()
    {
        PlierZone = GetComponentInChildren<XRSocketInteractor>();
        RightController = GameObject.Find("RightController");
        LeftController = GameObject.Find("LeftController");
        beingReleased = false;
        BroomCollider1 = transform.Find("BroomCollider1").GetComponent<MeshCollider>();
        BroomCollider2 = transform.Find("BroomCollider2").GetComponent<MeshCollider>();
        BroomCollider3 = transform.Find("BroomCollider3").GetComponent<MeshCollider>();
        BroomCollider4 = transform.Find("BroomCollider4").GetComponent<MeshCollider>();
        BroomCollider5 = transform.Find("BroomCollider5").GetComponent<MeshCollider>();
        BroomCollider6 = transform.Find("BroomCollider6").GetComponent<MeshCollider>();
        BroomCollider7 = transform.Find("BroomCollider7").GetComponent<MeshCollider>();
        BroomCollider8 = transform.Find("BroomCollider8").GetComponent<MeshCollider>();
        PliersBody = gameObject.GetComponent<Rigidbody>();
        ProperMass = PliersBody.centerOfMass; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Game_Manager.instance.RightGrab.firstInteractableSelected != null && Game_Manager.instance.RightGrab.firstInteractableSelected.Equals(gameObject) && !beingReleased)
        {
            if (other.CompareTag("JanitorBroom") && !other.GetComponentInParent<XRGrabInteractable>().isSelected)
            {
                var broom = other.transform.parent.parent.gameObject.GetComponent<XRGrabInteractable>();
                PlierZone.StartManualInteraction(broom);
                //PlierZone.ForceSnap(Broom);
                foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = false;
                }
                BroomCollider1.enabled = true;
                BroomCollider2.enabled = true;
                BroomCollider3.enabled = true;
                BroomCollider4.enabled = true;
                BroomCollider5.enabled = true;
                BroomCollider6.enabled = true;
                BroomCollider7.enabled = true;
                BroomCollider8.enabled = true;
                //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
                //{
                //    col.enabled = true;
                //    Debug.Log("children");
                //}
                Debug.Log("plierbroomcollidersright");
            }
        }
        else if (Game_Manager.instance.LeftGrab.firstInteractableSelected != null && Game_Manager.instance.LeftGrab.firstInteractableSelected.Equals(gameObject)
                && !beingReleased)
        {
            if (other.CompareTag("JanitorBroom") && !other.GetComponentInParent<XRGrabInteractable>().isSelected)
            {
                //this part will be a problem, the IXRInteractable interface needs to be looked at
                var broom = other.transform.parent.parent.gameObject.GetComponent<XRGrabInteractable>();
                PlierZone.StartManualInteraction(broom);
                foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = false;
                }
                BroomCollider1.enabled = true;
                BroomCollider2.enabled = true;
                BroomCollider3.enabled = true;
                BroomCollider4.enabled = true;
                BroomCollider5.enabled = true;
                BroomCollider6.enabled = true;
                BroomCollider7.enabled = true;
                BroomCollider8.enabled = true;
                //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
                //{
                //    col.enabled = true;
                //}
                Debug.Log("plierbroomcollidersleft");
            }
        }
    }

    public void ReleaseBroomRight()
    {
        if (Game_Manager.instance.RightGrab.firstInteractableSelected != null && Game_Manager.instance.RightGrab.firstInteractableSelected.Equals(gameObject) && !beingReleased)
        {
            beingReleased = true;
            Debug.Log("released");
            PlierZone.EndManualInteraction();
            BroomCollider1.enabled = false;
            BroomCollider2.enabled = false;
            BroomCollider3.enabled = false;
            BroomCollider4.enabled = false;
            BroomCollider5.enabled = false;
            BroomCollider6.enabled = false;
            BroomCollider7.enabled = false;
            BroomCollider8.enabled = false;
            PliersBody.centerOfMass = ProperMass;
            //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
            //{
            //    col.enabled = false;
            //}
            if (Broom != null)
            {
                foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = true;
                }
            }
            StartCoroutine("WaitForRelease");
        }
    }

    public void ReleaseBroomLeft()
    {
        if (Game_Manager.instance.LeftGrab.firstInteractableSelected != null && Game_Manager.instance.LeftGrab.firstInteractableSelected.Equals(gameObject) && !beingReleased)
        {
            beingReleased = true;
            Debug.Log("releasedleft");
            PlierZone.EndManualInteraction();
            BroomCollider1.enabled = false;
            BroomCollider2.enabled = false;
            BroomCollider3.enabled = false;
            BroomCollider4.enabled = false;
            BroomCollider5.enabled = false;
            BroomCollider6.enabled = false;
            BroomCollider7.enabled = false;
            BroomCollider8.enabled = false;
            PliersBody.centerOfMass = ProperMass;
            if (Broom != null)
            {
                foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = true;
                }
            }
            //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
            //{
            //    col.enabled = false;
            //}
            StartCoroutine("WaitForRelease");
        }
    }

    //private void Update()
    //{

    //    if (PlierZone.firstInteractableSelected == null || !PlierZone.firstInteractableSelected.transform.gameObject.CompareTag("JanitorBroom"))
    //    {
    //        foreach (MeshCollider col in gameObject.GetComponents<MeshCollider>())
    //        {
    //            col.enabled = false;
    //            Debug.Log("noplierbroomcolliders");
    //        }
    //        if (Broom != null)
    //        {
    //            foreach (MeshCollider col in Broom.transform.parent.GetComponentsInChildren<MeshCollider>())
    //            {
    //                col.enabled = true;
    //                Debug.Log("broomcolliderson");
    //            }
    //        }
    //    }
    //}
    IEnumerator WaitForRelease()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        beingReleased = false;     
    }
}
