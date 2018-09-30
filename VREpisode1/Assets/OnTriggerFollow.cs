using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Grabbable water")
        {
            this.transform.parent = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Grabbable water")
        {
            this.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
