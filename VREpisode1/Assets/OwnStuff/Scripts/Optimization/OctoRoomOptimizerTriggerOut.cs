using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoRoomOptimizerTriggerOut : MonoBehaviour {

    WaterMovement water;


    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
    }

    private void OnTriggerEnter(Collider other)    //entering elevator from OctoRoom, we cannot go back to shafts
    {
        if (other == (water.head || water.feet))
        {
            OptimizeRendering.insideOctoRoom = false;                    
            OptimizeRendering.renderingChanged = false;
        }
    }
}
