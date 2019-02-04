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

    void Start()
    {
        notWaited = true;
        SwitchAnim = GetComponent<Animator>();
        SwitchSnap = GameObject.Find("SwitchBoxSnapZone").GetComponent<VRTK_SnapDropZone>();
    }


    void Update()
    {
        if (SwitchSnap.GetCurrentSnappedObject() != null)
        {
            if (SwitchSnap.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
            {
                Debug.Log("entered");
                foreach (JanitorBroomTransformer rend in SwitchSnap.GetCurrentSnappedObject().GetComponentsInChildren<JanitorBroomTransformer>())
                    if (rend.changeBroomColour)
                    {
                        SwitchAnim.SetBool("Crack", true);
                        if (notWaited)
                        {
                            notWaited = false;
                            StartCoroutine("Wait");
                        }
                        //foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().GetComponentsInChildren<MeshRenderer>())
                        //{
                        //    child.enabled = false;
                        //}
                        break;
                    }
                else
                    {
                        continue;
                    }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        foreach (MeshRenderer child in SwitchSnap.GetCurrentSnappedInteractableObject().GetComponentsInChildren<MeshRenderer>())
        {
            child.enabled = false;
            GetComponent<VRTK_PhysicsRotator>().isLocked = false;
        }
        foreach (Collider child in SwitchSnap.GetCurrentSnappedInteractableObject().GetComponentsInChildren<Collider>())
        {
            child.enabled = false;          
        }
    }
}
