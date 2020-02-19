using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUnderWaterGrab : UnderWaterGrabbableObject {

    protected override void Start()
    {
        damagedByWater = false;
        DamagedSound = null;
        GrabbableWater = GameObject.Find("Water/GrabbableWater");
        lefthandPartsTouchingWaterObject = 0;
        righthandPartsTouchingWaterObject = 0;
        waterGrabbingNotAllowed = false;
    }

    protected override void OnTriggerEnter(Collider other)
    {    
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
}
