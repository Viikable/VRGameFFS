using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SkeletonKey : MonoBehaviour
{
    public bool damagedByWater;
    public AudioSource DamagedSound;
    public GameObject GrabbableWater;

    void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
        GrabbableWater = GameObject.Find("Water/GrabbableWater");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && !damagedByWater)
        {
            damagedByWater = true;
            DamagedSound.Play();
        }
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                Lantern.lefthandPartsTouchingWaterObject += 1;
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                Lantern.righthandPartsTouchingWaterObject += 1;
            }
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
    //    {
    //        if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
    //        {
    //            Lantern.lefthandPartsTouchingWaterObject = true;
    //        }
    //        else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
    //        {
    //            Lantern.righthandPartsTouchingWaterObject = true;
    //        }
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                Lantern.lefthandPartsTouchingWaterObject -= 1;
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                Lantern.righthandPartsTouchingWaterObject -= 1;
            }
        }
    }
}


