using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class BoxFloat : MonoBehaviour {
    private bool startMoving;
    private bool notTouched;
    //public int whatSideofTheBoxDown;
    Animator FloatAnim;

    private void Awake()
    {
        //whatSideofTheBoxDown = 0;
        startMoving = false;
        notTouched = true;
        FloatAnim = transform.parent.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && notTouched)
        {
            notTouched = false;
            StartCoroutine("WaitForRealism");            
        }
        //if (other.name == "Lantern" && !other.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        //{
        //    other.transform.parent = transform;
        //}
        //if (other.name == "ShaftCeiling")
        //{
        //    stop = true;
        //}
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.name == "Lantern")
    //    {
    //        other.transform.parent = null;
    //    }
    //}
    
    IEnumerator WaitForRealism()
    {
        yield return new WaitForSeconds(1.5f);
        startMoving = true;
    }

    void Update () {

        if (startMoving)
        {
            GetComponent<Rigidbody>().useGravity = false;
            FloatAnim.SetBool("Float", true);
            GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = GetComponent<VRTK_ClimbableGrabAttach>();
            //GetComponent<VRTK_InteractableObject>().isGrabbable = false;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().isKinematic = true;
            //if (whatSideofTheBoxDown == 0)
            //{
                transform.Translate(Vector3.up * 0.2f * Time.deltaTime, Space.World);
                //if (transform.eulerAngles != new Vector3(-1.981f, -154.381f, 0.72f))
                //{
                //    Vector3 correctRotation = new Vector3(-1.981f, -154.381f, 0.72f);

                //     transform.eulerAngles = correctRotation;
                //    }
            }
        }              
   }

