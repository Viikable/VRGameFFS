using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class LampButton : MonoBehaviour {

    VRTK_PhysicsPusher Lampbutton;
    public Light LampLight;
    bool clicked;
	
	void Start ()
    {
        Lampbutton = GetComponent<VRTK_PhysicsPusher>();
        clicked = false;
	}
	
	
	void Update ()
    {		
        if (Lampbutton.AtMaxLimit() && !clicked)
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
        else if (Lampbutton.AtMinLimit() && clicked)
        {
            clicked = false;
        }
	}
}
