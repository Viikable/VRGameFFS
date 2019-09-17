using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterOptimizerTriggerIn : MonoBehaviour {

    WaterMovement water;


    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == (water.head || water.feet))
        {
            OptimizeRendering.insideMelterArea = true;
            OptimizeRendering.insideMainHall = false;
            OptimizeRendering.insideOctoRoom = false;
            OptimizeRendering.insideShafts = false;
            OptimizeRendering.renderingChanged = false;
        }
    }
}
