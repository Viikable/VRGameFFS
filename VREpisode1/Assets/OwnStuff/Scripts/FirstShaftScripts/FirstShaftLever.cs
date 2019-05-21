using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class FirstShaftLever : MonoBehaviour {
    VRTK_PhysicsRotator HatchOpenSwitch;
    Animator FirstShaft;

    void Start()
    {
        HatchOpenSwitch = GetComponent<VRTK_PhysicsRotator>();
        FirstShaft = GameObject.Find("GateDownShaft").GetComponent<Animator>();
    }
	
	
	void Update () {
		if (HatchOpenSwitch.AtMaxLimit())
        {
            FirstShaft.SetBool("Open", true);
        }
	}
}
