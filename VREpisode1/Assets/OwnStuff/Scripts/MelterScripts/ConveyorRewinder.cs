﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorRewinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            if (other.transform.parent.transform.CompareTag("ConveyorBeltMetal"))
            {
            other.transform.parent.transform.position = new Vector3(-24.4f, 2.2f, 8.7f);
            //other.transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}