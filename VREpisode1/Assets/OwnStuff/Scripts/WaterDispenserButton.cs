using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class WaterDispenserButton : MonoBehaviour {
    [SerializeField]
    float time;
    [SerializeField]
    bool buttonIsUp;
    bool timeNotSet;

    private void Start()
    {
        timeNotSet = true;
        buttonIsUp = false;
        time = 0f;
    }

    void Update () {
		if (this.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f 
            && this.GetComponent<VRTK_PhysicsPusher>().stayPressed && timeNotSet)
        {
            Debug.Log("time set");
            time = Time.time;
            buttonIsUp = false;
            timeNotSet = false;
        }
        if (time != 0f && Time.time >= time + 5f && !buttonIsUp)
        {
            Debug.Log("button up");
            this.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            buttonIsUp = true;
        }
        if (Time.time >= time + 5.1f && buttonIsUp && !timeNotSet)
        {
            Debug.Log("button can be pressed again");
            this.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            timeNotSet = true;
        }      
	}
}
