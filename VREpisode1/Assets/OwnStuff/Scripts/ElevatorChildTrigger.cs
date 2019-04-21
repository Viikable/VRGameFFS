using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ElevatorChildTrigger : MonoBehaviour {
    GameObject mainSDK;
    GameObject Elevator;
   
    void Start () {
        mainSDK = GameObject.Find("SDKSetups");
        Elevator = GameObject.Find("ELEVATOR2.0");
	}
	
    private void OnTriggerEnter(Collider other)
    {
        mainSDK.transform.parent = Elevator.transform;
        
    }
    private void OnTriggerExit(Collider other)
    {
        mainSDK.transform.parent = null;
    }

    void Update () {
		
	}
}
