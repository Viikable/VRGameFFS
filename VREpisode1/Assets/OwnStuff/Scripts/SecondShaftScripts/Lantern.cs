using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour {

    public bool damagedByWater;
    public AudioSource DamagedSound;
    public Light LanternLight;

    void Start()
    {
        damagedByWater = false;
        DamagedSound = GetComponentInChildren<AudioSource>();
        LanternLight = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && !damagedByWater)
        {
            damagedByWater = true;
            DamagedSound.Play();
            LanternLight.enabled = false;
        }
    }
}
