using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

public class SwitchBoxOpening : MonoBehaviour
{
    Animator SwitchAnim;
    public VRTK_SnapDropZone SwitchSnap;  
    bool notWaited;
    bool metallicBroom;
    int metallicBroomParts;
    public AudioSource BroomBreaksSound;
    public AudioSource BroomOpensLockerSound;
    Vector3 BroomPosition;

    void Start()
    {
        notWaited = true;
        SwitchAnim = GetComponent<Animator>();
        SwitchSnap = GameObject.Find("SwitchBoxSnapZone").GetComponent<VRTK_SnapDropZone>();
        metallicBroom = false;
        metallicBroomParts = 0;
        BroomBreaksSound = GameObject.Find("BroomBreaksSound").GetComponent<AudioSource>();
        BroomOpensLockerSound = GameObject.Find("BroomOpensLockerSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log(BroomPosition);
        if (SwitchSnap.GetCurrentSnappedObject() != null)
        {
            if (SwitchSnap.GetCurrentSnappedObject().CompareTag("JanitorBroom") && notWaited)
            {
                Debug.Log("entered");
                foreach (JanitorBroomTransformer rend in SwitchSnap.GetCurrentSnappedObject().transform.GetChild(0).GetComponentsInChildren<JanitorBroomTransformer>())
                    if (rend.changeBroomColour)
                    {
                        metallicBroomParts++;
                        
                        if (notWaited && metallicBroomParts >= 6)
                        {
                            SwitchAnim.SetBool("Crack", true);
                            BroomOpensLockerSound.Play();
                            notWaited = false;
                            foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<MeshRenderer>())
                            {
                                child.enabled = false;
                            }
                            GameObject.Find("Switch_box").GetComponent<VRTK_PhysicsRotator>().isLocked = false;
                            GetComponent<VRTK_PhysicsRotator>().angleLimits = new Limits2D(25f, -90f);
                            foreach (Collider child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<Collider>())
                            {
                                child.enabled = false;
                            }
                            metallicBroom = true;
                            Debug.Log("crackLock");
                            StartCoroutine("MetallicBroomOpensLocker"); //waits for the animation of broom opening the locker to finish, then moves the broom which was snapped to that position
                        break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                if (!metallicBroom)
                {
                    metallicBroomParts = 0;
                    notWaited = false;
                    SwitchAnim.SetBool("Break", true);                    
                    BroomBreaksSound.Play();
                    foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<MeshRenderer>())
                    {
                        child.enabled = false;
                    }
                    GetComponent<VRTK_PhysicsRotator>().angleLimits = new Limits2D(25f, -90f);
                    foreach (Collider child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<Collider>())
                    {
                        child.enabled = false;
                    }
                    StartCoroutine("BroomBreaks");
                    Debug.Log("BrokenBroom");
                }
            }
        }
    }
    IEnumerator MetallicBroomOpensLocker()
    {
        yield return new WaitForSecondsRealtime(2f);
        BroomPosition = transform.TransformPoint(GameObject.Find("BroomInTheJanitorAnimationBroom").transform.localPosition);
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.position = BroomPosition;
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.rotation = GameObject.Find("BroomInTheJanitorAnimationBroom").transform.rotation;
        foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<MeshRenderer>())
        {
            child.enabled = true;
        }
        foreach (Collider child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<Collider>())
        {
            child.enabled = true;
        }
        SwitchSnap.enabled = false;
        GameObject.Find("SwitchContainer").GetComponent<VRTK_PhysicsRotator>().isLocked = false; //unlocks the lever inside, it's locked before so can't pull it through the door
        Destroy(SwitchSnap);
    }

    IEnumerator BroomBreaks()
    {
        yield return new WaitForSecondsRealtime(1f);
        BroomPosition = transform.TransformPoint(GameObject.Find("BroomInTheJanitorAnimationBroom2").transform.localPosition);
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.position = BroomPosition;
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.TransformPoint(GameObject.Find("BroomInTheJanitorAnimationBroom2").transform.localRotation.eulerAngles);
        foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<MeshRenderer>())
        {
            child.enabled = true;
        }
        foreach (Collider child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<Collider>())
        {
            child.enabled = true;
        }
        foreach (Transform child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<Transform>())
        {
            child.gameObject.AddComponent<Rigidbody>();         
            child.gameObject.AddComponent<VRTK_InteractableObject>();
            child.gameObject.AddComponent<VRTK_FixedJointGrabAttach>();
            child.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
            child.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = child.gameObject.GetComponent<VRTK_FixedJointGrabAttach>();
            child.GetComponent<VRTK_InteractableObject>().secondaryGrabActionScript = child.gameObject.GetComponent<VRTK_SwapControllerGrabAction>();
            child.GetComponent<VRTK_InteractableObject>().holdButtonToGrab = true;
            child.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
            child.gameObject.GetComponent<VRTK_FixedJointGrabAttach>().breakForce = 10000;
            child.gameObject.GetComponent<VRTK_FixedJointGrabAttach>().precisionGrab = true;
            child.gameObject.tag = "BrokenBroom";
            child.parent = null;
        }             
        SwitchAnim.SetBool("Break", false);
        SwitchSnap.ForceUnsnap();
        notWaited = true;       
    }
}
