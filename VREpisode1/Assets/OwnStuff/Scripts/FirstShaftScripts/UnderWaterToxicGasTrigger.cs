using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterToxicGasTrigger : MonoBehaviour {

    public ParticleSystem JuhaniUnderWaterLeak;
    bool underWater;

    private void Start()
    {
        JuhaniUnderWaterLeak = transform.parent.GetComponent<ParticleSystem>();
        underWater = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && !underWater)
        {
            JuhaniUnderWaterLeak.Play();
            underWater = true;
        }
    }
}
