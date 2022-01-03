using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LampButton : MonoBehaviour {

    Button Lampbutton;
    public Light LampLight;
    bool clicked;
	
	void Start ()
    {
        Lampbutton = GetComponent<Button>();
        clicked = false;
	}
	
	
	void Update ()
    {		
        if (Lampbutton.isPressedDown && !clicked)
        {
            if (!LampLight.enabled)
            {
                LampLight.enabled = true;
            }
            else
            {
                LampLight.enabled = false;
            }
            clicked = true;
        }
        else if (Lampbutton.isAtStartPosition && clicked)
        {
            clicked = false;
        }
	}
}
