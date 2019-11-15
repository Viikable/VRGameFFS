using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoRoomOptizimerTriggerIn : MonoBehaviour {
    WaterMovement water;
	

	void Start () {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other == (WaterMovement.head || WaterMovement.feet))
        {
            OptimizeRendering.insideOctoRoom = true;
            OptimizeRendering.insideMainHall = false;
            OptimizeRendering.insideShafts = false;
            OptimizeRendering.insideMelterArea = false;
            OptimizeRendering.renderingChanged = false;
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "OctoRoom";
        }
    }  
}
