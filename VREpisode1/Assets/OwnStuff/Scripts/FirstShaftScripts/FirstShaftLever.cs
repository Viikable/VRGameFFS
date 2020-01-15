using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class FirstShaftLever : MonoBehaviour {
    VRTK_PhysicsRotator HatchOpenSwitch;
    Animator FirstShaft;
    AudioSource GateOpenSound;
    bool firstHatchClosed;

    void Start()
    {
        HatchOpenSwitch = GetComponent<VRTK_PhysicsRotator>();
        FirstShaft = GameObject.Find("GateDownShaft").GetComponent<Animator>();
        firstHatchClosed = true;
        GateOpenSound = FirstShaft.GetComponent<AudioSource>();
    }
	
	void Update ()
    {
		if (HatchOpenSwitch.AtMaxLimit() && firstHatchClosed)
        {
            firstHatchClosed = false;
            GateOpenSound.Play();
            FirstShaft.SetBool("Open", true);
        }
	}
}
