using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ConveyorBeltMetal")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ConveyorBeltMetal")
        {
            other.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
