using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftsOptimizerTriggerOutToMainHall : MonoBehaviour {

    WaterMovement water;
    ParticleSystem GasLeak;


    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
        GasLeak = GameObject.Find("ToxicGasLeak").GetComponent<ParticleSystem>();
        //GasLeak.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == (WaterMovement.head || WaterMovement.feet))
        {
            OptimizeRendering.insideShafts = false;
            OptimizeRendering.insideMainHall = true;
            OptimizeRendering.renderingChanged = false;
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "MainHall";
            if (!ClimbableHeadAppears.toxicLeakChanged)
            {
            GasLeak.Stop();
            }
        }
    }
}
