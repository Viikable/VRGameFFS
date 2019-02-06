using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Ledge : MonoBehaviour {
    VRTK_SnapDropZone ledgeSnap;
    int i;

	// Use this for initialization
	void Start () {
        ledgeSnap = GameObject.Find("MelterWalkableLedgeSnapZone").GetComponent<VRTK_SnapDropZone>();
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (ledgeSnap.GetCurrentSnappedObject() == this && i == 0)
        {
            GetComponent<VRTK_InteractableObject>().isGrabbable = false;
            GetComponent<Rigidbody>().isKinematic = true;
            i++;
        }
	}
}
