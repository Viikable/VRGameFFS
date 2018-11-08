using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStopper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater")
        {
            WaterMovement.waterRises = false;
        }
    }
    // Update is called once per frame
    void Update () {
        
	}
}
