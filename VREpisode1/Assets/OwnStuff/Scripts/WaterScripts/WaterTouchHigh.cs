using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTouchHigh : MonoBehaviour {
    WaterMovement water;

    void Start()
    {
        water = transform.parent.GetComponentInParent<WaterMovement>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == water.feet)
        {
            Debug.Log("feet exited water");
            WaterMovement.touchedWater = false;
        }
        if (other == water.head)
        {
            if (!water.Splash.isPlaying)
            {
                water.Splash.Play();
            }
            WaterMovement.headIsUnderWater = false;
            Debug.Log("head exited water");
            water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
            //touchedWater = false;
            WaterMovement.fader.Unfade(0.25f);

            //if (ButtonSwimming.swimUp)
            //{
            //    GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
            //}
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
