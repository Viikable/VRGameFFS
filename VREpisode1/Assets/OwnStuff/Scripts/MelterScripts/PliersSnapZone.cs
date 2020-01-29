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
    public static bool beingReleased;

    protected void Awake()
    {
        PlierZone = GetComponentInChildren<VRTK_SnapDropZone>();
        RightController = GameObject.Find("RightController");
        LeftController = GameObject.Find("LeftController");
        beingReleased = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject() == gameObject && !beingReleased)
        {
            if (other.CompareTag("JanitorBroom") && !other.GetComponentInParent<VRTK_InteractableObject>().IsGrabbed())
            {
                Broom = other.transform.parent.parent.gameObject;
                Debug.Log(Broom);
                PlierZone.ForceSnap(Broom);
                //foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
                //{
                //    col.enabled = false;                 
                //}
                //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
                //{
                //    col.enabled = true;
                //    Debug.Log("children");
                //}
                Debug.Log("plierbroomcollidersright");
            }
        }
        if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject() == gameObject
                && !beingReleased)
        {
            if (other.CompareTag("JanitorBroom") && !other.GetComponentInParent<VRTK_InteractableObject>().IsGrabbed())
            {
                Broom = other.transform.parent.parent.gameObject;
                PlierZone.ForceSnap(Broom);
                //foreach (MeshCollider col in Broom.transform.parent.GetComponentsInChildren<MeshCollider>())
                //{
                //    col.enabled = false;
                //}
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
        if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject() == gameObject && !beingReleased)
        {
            beingReleased = true;
            Debug.Log("released");
            PlierZone.ForceUnsnap();
            //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
            //{
            //    col.enabled = false;
            //}
            //if (Broom != null)
            //{
            //    foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
            //    {
            //        col.enabled = true;
            //    }
            //}
            StartCoroutine("WaitForRelease");
        }
    }

    public void ReleaseBroomLeft()
    {
        if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject() == gameObject && !beingReleased)
        {
            beingReleased = true;
            Debug.Log("releasedleft");
            PlierZone.ForceUnsnap();
            //foreach (MeshCollider col in gameObject.GetComponentsInChildren<MeshCollider>())
            //{
            //    col.enabled = false;
            //}
            //if (Broom != null)
            //{
            //    foreach (MeshCollider col in Broom.GetComponentsInChildren<MeshCollider>())
            //    {
            //        col.enabled = true;                  
            //    }
            //}
            StartCoroutine("WaitForRelease");
        }
    }

    //private void Update()
    //{

    //    if (PlierZone.GetCurrentSnappedObject() == null || !PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
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
        yield return new WaitForSecondsRealtime(2f);
        beingReleased = false;             
    }
}
