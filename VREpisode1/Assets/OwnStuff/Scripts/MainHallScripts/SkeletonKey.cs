using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SkeletonKey : UnderWaterGrabbableObject
{
    //the same as in FloatingObject, just testing
    protected override void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
        GrabbableWater = GameObject.Find("Water/GrabbableWater");
    }
    
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GrabbableWater && !damagedByWater)
        {
            damagedByWater = true;
            DamagedSound.Play();
        }
        if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
        {
            if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
            {
                lefthandPartsTouchingWaterObject += 1;
            }
            else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
            {
                righthandPartsTouchingWaterObject += 1;
            }
        }
    }
    //this method is inherited

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
    //    {
    //        if (other.transform.parent.parent.name == "VRTK_LeftBasicHand")
    //        {
    //            lefthandPartsTouchingWaterObject -= 1;
    //        }
    //        else if (other.transform.parent.parent.name == "VRTK_RightBasicHand")
    //        {
    //            righthandPartsTouchingWaterObject -= 1;
    //        }
    //    }
    //}
}


