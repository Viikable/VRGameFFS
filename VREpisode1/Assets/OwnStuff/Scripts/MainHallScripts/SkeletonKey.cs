using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKey : MonoBehaviour
{
    public bool damagedByWater;
    public AudioSource DamagedSound;


    void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && !damagedByWater)
        {
            damagedByWater = true;
            DamagedSound.Play();
        }
    }
}
