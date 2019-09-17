using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftsOptimizerTriggerIn : MonoBehaviour {
    WaterMovement water;


    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
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
        }
    }
}
