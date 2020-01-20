using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class MiddleHatchOpening : MonoBehaviour
{
    VRTK_PhysicsPusher MiddleShaftButton;
    Animator MiddleHatchAnim;
    bool notOpen;
	
	void Start ()
    {
        MiddleShaftButton = GetComponent<VRTK_PhysicsPusher>();
        MiddleHatchAnim = GameObject.Find("GateMiddle").GetComponent<Animator>();
        notOpen = true;
	}
	
	
	void Update ()
    {
		if (MiddleShaftButton.AtMaxLimit() && notOpen)
        {
            notOpen = false;
            MiddleHatchAnim.SetBool("Open", true);
        }
	}
}
