using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutting : MonoBehaviour {
    ConfigurableJoint jahas;
	// Use this for initialization
	void Start () {
        jahas = this.GetComponent<ConfigurableJoint>();

    }

    private void OnTriggerEnter(Collider other)
    {
        jahas = this.GetComponent<ConfigurableJoint>();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
