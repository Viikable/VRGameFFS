using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterOptimizerTriggerOutToMainHall : MonoBehaviour {

    WaterMovement water;


    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == (WaterMovement.head || WaterMovement.feet))
        {
            OptimizeRendering.insideMelterArea = false;
            OptimizeRendering.insideMainHall = true;           
            OptimizeRendering.renderingChanged = false;
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "MainHall";
        }
    }
}
