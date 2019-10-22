using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftsOptimizerTriggerIn : MonoBehaviour {
    WaterMovement water;
    ParticleSystem GasLeak;

    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
        GasLeak = GameObject.Find("ToxicGasLeak").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == (water.head || water.feet))
        {
            OptimizeRendering.insideShafts = true;
            OptimizeRendering.insideMainHall = false;
            OptimizeRendering.insideOctoRoom = false;
            OptimizeRendering.insideMelterArea = false;
            OptimizeRendering.renderingChanged = false;
            GasLeak.Play();
            //because this is after the exit from main hall, we don't know if player has got access to the shaft yet
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "JanitorsLodge";
        }
    }
}
