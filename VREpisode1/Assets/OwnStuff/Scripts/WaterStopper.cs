using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStopper : MonoBehaviour {
    private WaterMovement water;
	// Use this for initialization
	void Start () {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterStopper")               //when the invisible plane under OctoRoom is touched, watermovement stops
        {
            Debug.Log("stopped");
            water.WaterRises = false;
        }
    }
    // Update is called once per frame
    void Update () {
        
	}
}
