using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : UnderWaterGrabbableObject {

    public Light LanternLight;
   
    protected override void Start ()
    {
        LanternLight = GetComponent<Light>();
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
        GrabbableWater = GameObject.Find("Water/GrabbableWater");
        lefthandPartsTouchingWaterObject = 0;
        righthandPartsTouchingWaterObject = 0;
        waterGrabbingNotAllowed = false;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GrabbableWater && !damagedByWater)
        {
            damagedByWater = true;
            DamagedSound.Play();
            LanternLight.enabled = false;
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
}
