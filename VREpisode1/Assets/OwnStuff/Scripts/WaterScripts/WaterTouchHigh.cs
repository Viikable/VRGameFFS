using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTouchHigh : MonoBehaviour
{
    WaterMovement water;
    public AudioSource DrowningAlertSounds;
    void Start()
    {
        water = transform.parent.GetComponentInParent<WaterMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == WaterMovement.feet && WaterMovement.touchedWater)
        {
            Debug.Log("feet exited water");
            WaterMovement.touchedWater = false;
        }
        if (other == WaterMovement.head && WaterMovement.headIsUnderWater)
        {
            DrowningAlertSounds.Stop();
            if (!water.Splash.isPlaying)
            {
                water.Splash.Play();
            }
            Debug.Log("head exited water");
            water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
            WaterMovement.fader.Unfade(0.25f);
            WaterMovement.headIsUnderWater = false;
            //test
            //ToxicGasPush.PlayerBody.isKinematic = true;
            //StartCoroutine("TurnBackToNonKinematic");
        }
    }
    IEnumerator TurnBackToNonKinematic()
    {
        yield return new WaitForEndOfFrame();
        ToxicGasPush.PlayerBody.isKinematic = false;
    }
}
