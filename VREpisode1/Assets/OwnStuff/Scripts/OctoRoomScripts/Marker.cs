using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Marker : MonoBehaviour {
    GameObject marker;
	
	void Start () {
        marker = gameObject;
	}
		
	void Update () {
		if (marker.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        {
            marker.transform.parent = marker.GetComponent<VRTK_InteractableObject>().GetGrabbingObject().transform;
        }
        else if (!marker.GetComponent<VRTK_InteractableObject>().IsInSnapDropZone())
        {
            marker.transform.parent = null;
        }
	}
}
