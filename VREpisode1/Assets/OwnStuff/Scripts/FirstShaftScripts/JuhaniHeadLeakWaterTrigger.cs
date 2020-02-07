using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuhaniHeadLeakWaterTrigger : MonoBehaviour
{
    public ParticleSystem JuhaniHeadLeakUnderWater;
    public ParticleSystem JuhaniHeadLeak;
    bool underwater;

    void Start ()
    {
        JuhaniHeadLeakUnderWater = GameObject.Find("ToxicGasLeakUnderwater").GetComponent<ParticleSystem>();
        JuhaniHeadLeak = GameObject.Find("ToxicGasLeakMouth").GetComponent<ParticleSystem>();
        underwater = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && !underwater)
        {
            underwater = true;
            JuhaniHeadLeak.Stop();
            JuhaniHeadLeakUnderWater.Play();
        }
    }
}
