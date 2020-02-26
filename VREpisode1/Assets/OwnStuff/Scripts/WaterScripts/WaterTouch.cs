using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTouch : MonoBehaviour
{
    WaterMovement water;
    public static bool dontLightHands;

    void Start()
    {
        water = transform.parent.GetComponentInParent<WaterMovement>();
        dontLightHands = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == WaterMovement.feet && !WaterMovement.touchedWater)
        {
            Debug.Log("feet entered water");
            if (!water.Splash.isPlaying)
            {
                water.Splash.Play();
            }
            WaterMovement.touchedWater = true;
        }
        if (other == WaterMovement.head)
        {
            water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
            //WaterMovement.touchedWater = true;
            Debug.Log("head entered water");
            WaterMovement.timeWhenGotUnderwater = Time.time;
            WaterMovement.headIsUnderWater = true;
            //Debug.Log(WaterMovement.timeWhenGotUnderwater);
            dontLightHands = true; //this causes hands to not light up when head goes under water, but it won't prevent them lighting up when inside wall in water etc.
            WaterMovement.fader.Fade(Color.black, 150f);
        }
    }
}