using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTouch : MonoBehaviour {
    WaterMovement water;
	// Use this for initialization
	void Start () {
        water = GameObject.Find("Water").GetComponent<WaterMovement>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == water.feet)
        {
            Debug.Log("Splash");
            if (!water.Splash.isPlaying)
            {
            water.Splash.Play();
            }
            //water.touchedWater = true;
        }
        if (other == water.head)
        {
            water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
            water.touchedWater = true;
            Debug.Log("head entered water");
            water.timeWhenGotUnderwater = Time.time;
            water.headIsUnderWater = true;
            //Debug.Log(timeWhenGotUnderwater);
            water.fader.Fade(Color.black, 80f);
        }
    }
}
