using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKey : MonoBehaviour
{
    public bool DamagedByWater;

    void Start()
    {
        DamagedByWater = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater")
        {
            DamagedByWater = true;
        }
    }
}
