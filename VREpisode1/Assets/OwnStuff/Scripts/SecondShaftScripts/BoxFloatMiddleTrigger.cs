﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFloatMiddleTrigger : MonoBehaviour {

    bool notTouched;

	void Start ()
    {
        notTouched = true;	
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LowWaterTrigger" && notTouched)
        {
            notTouched = false;
            StartCoroutine("WaitForRealism");
            BoxFloat.tooDeep = false;
        }
        if (other.name == "BoxFloatColliderTriggerHigh" && BoxFloat.tooDeep)
        {
            BoxFloat.tooDeep = false;
            Debug.Log("toodeep false");
            BoxFloat.boxBody.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine("KinematicFrame");
        }
    }

    IEnumerator WaitForRealism()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        BoxFloat.startMoving = true;
    }

    IEnumerator KinematicFrame()
    {
        yield return new WaitForEndOfFrame();
        BoxFloat.boxBody.constraints = RigidbodyConstraints.None;
        //BoxFloat.boxBody.isKinematic = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "BoxFloatColliderTriggerLow")
        {
            BoxFloat.tooDeep = true;
            Debug.Log("toodeep true");
        }
    }
}
