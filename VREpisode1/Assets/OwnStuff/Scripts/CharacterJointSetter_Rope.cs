using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJointSetter_Rope : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
