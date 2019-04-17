using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShaftTopOpening : MonoBehaviour {

    VRTK_SnapDropZone ShaftTopZone;
    Animator TopShaftHatch;
	
	void Start () {
        ShaftTopZone = GetComponent<VRTK_SnapDropZone>();
        TopShaftHatch = GameObject.Find("GateShaftEnd").GetComponent<Animator>();
	}
	
	void Update () {
		if (ShaftTopZone.GetCurrentSnappedObject() != null)
        {
            TopShaftHatch.SetBool("Open", true);
        }
	}
}
