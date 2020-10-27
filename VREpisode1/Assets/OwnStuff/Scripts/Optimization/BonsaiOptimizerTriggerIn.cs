using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonsaiOptimizerTriggerIn : MonoBehaviour {
    WaterMovement water;

    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == (WaterMovement.head || WaterMovement.feet))
        {
            OptimizeRendering.insideBonsaiRoom = true;
            OptimizeRendering.insideShafts = false;
            OptimizeRendering.insideMainHall = false;
            OptimizeRendering.insideOctoRoom = false;
            OptimizeRendering.insideMelterArea = false;
            OptimizeRendering.renderingChanged = false;                                
        }
    }
}
