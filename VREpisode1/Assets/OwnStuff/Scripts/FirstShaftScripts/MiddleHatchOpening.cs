using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class MiddleHatchOpening : MonoBehaviour
{
    Button MiddleShaftButton;
    Animator MiddleHatchAnim;
    bool notOpen;
	
	void Start ()
    {
        MiddleShaftButton = GetComponent<Button>();
        MiddleHatchAnim = GameObject.Find("GateMiddle").GetComponent<Animator>();
        notOpen = true;
	}
	
	
	void Update ()
    {
		if (MiddleShaftButton.isPressedDown && notOpen)
        {
            notOpen = false;
            MiddleHatchAnim.SetBool("Open", true);
        }
	}
}
