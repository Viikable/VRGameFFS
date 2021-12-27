using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirstShaftLever : MonoBehaviour {
    HingeJoint HatchOpenSwitch;
    Animator FirstShaft;
    AudioSource GateOpenSound;
    bool firstHatchClosed;

    void Start()
    {
        HatchOpenSwitch = GetComponent<HingeJoint>();
        FirstShaft = GameObject.Find("GateDownShaft").GetComponent<Animator>();
        firstHatchClosed = true;
        GateOpenSound = FirstShaft.GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        //have to test the limits 
		if (HatchOpenSwitch.limits.Equals(HatchOpenSwitch.limits.max) && firstHatchClosed)
        {
            firstHatchClosed = false;
            GateOpenSound.Play();
            FirstShaft.SetBool("Open", true);
        }
	}
}
