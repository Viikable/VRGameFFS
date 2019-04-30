using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTouchHigh : MonoBehaviour {
    WaterMovement water;
    // Use this for initialization
    void Start()
    {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == water.feet)
        {
            Debug.Log("feet exited water");
            water.touchedWater = false;
        }
        if (other == water.head)
        {
            if (!water.Splash.isPlaying)
            {
            water.Splash.Play();
            }
            water.headIsUnderWater = false;
            Debug.Log("head exited water");
            water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
            //touchedWater = false;
            water.fader.Unfade(3f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
