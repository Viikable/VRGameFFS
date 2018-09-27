using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour {
    Animator anim;
    public static bool PressedScreen1 = false;
    public static bool PressedScreen2 = false;
    public static bool PressedScreen3 = false;
    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PressedScreen1)
        {
            anim.SetBool("Start", true);
        }
        if (PressedScreen2)
        {
            anim.SetBool("Open", true);
        }
	}
}
