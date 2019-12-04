using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class SwitchBoxOpening : MonoBehaviour
{
    Animator SwitchAnim;
    public VRTK_SnapDropZone SwitchSnap;
    public Material CharredBroom;
    bool notWaited;
    bool metallicBroom;
    int metallicBroomParts;

    void Start()
    {
        notWaited = true;
        SwitchAnim = GetComponent<Animator>();
        SwitchSnap = GameObject.Find("SwitchBoxSnapZone").GetComponent<VRTK_SnapDropZone>();
        metallicBroom = false;
        metallicBroomParts = 0;
    }

    void Update()
    {
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
                            notWaited = false;
                            foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<MeshRenderer>())
                            {
                                child.enabled = false;
                            }
                            GetComponent<VRTK_PhysicsRotator>().angleLimits = new Limits2D(25f, -90f);
                            foreach (Collider child in SwitchSnap.GetCurrentSnappedInteractableObject().transform.GetChild(0).GetComponentsInChildren<Collider>())
                            {
                                child.enabled = false;
                            }
                            metallicBroom = true;
                            StartCoroutine("WaitAnimationFinish"); //waits for the animation of broom opening the locker to finish, then moves the broom which was snapped to that position
                        break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                if (!metallicBroom)
                {
                    notWaited = false;
                    SwitchAnim.SetBool("Break", true);
                    StartCoroutine("BroomBreaks");
                    Debug.Log("BrokenBroom");
                }
            }
        }
    }
    IEnumerator WaitAnimationFinish()
    {
        yield return new WaitForSecondsRealtime(2f);
        Vector3 pos = this.transform.TransformPoint(GameObject.Find("BroomInTheJanitorAnimationBroom").transform.localPosition);
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.position = pos;
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
        Vector3 pos = this.transform.TransformPoint(GameObject.Find("BroomInTheJanitorAnimationBroom").transform.localPosition);
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.position = pos;
        SwitchSnap.GetCurrentSnappedInteractableObject().transform.rotation = GameObject.Find("BroomInTheJanitorAnimationBroom").transform.rotation;
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
            child.parent = null;
        }
        SwitchSnap.GetCurrentSnappedInteractableObject().tag = "BrokenBroom";
        SwitchAnim.SetBool("Break", false);
        SwitchSnap.ForceUnsnap();
    }
}
