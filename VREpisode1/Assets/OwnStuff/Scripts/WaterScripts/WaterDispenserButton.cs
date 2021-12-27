using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
		if (this.GetComponent<Button>().isPressedDown 
            && this.GetComponent<Button>().stayPressed && timeNotSet)
        {
            Debug.Log("time set");
            time = Time.time;
            buttonIsUp = false;
            timeNotSet = false;
        }
        if (time != 0f && Time.time >= time + 5f && !buttonIsUp)
        {
            Debug.Log("button up");
            this.GetComponent<Button>().stayPressed = false;
            buttonIsUp = true;
        }
        if (Time.time >= time + 5.1f && buttonIsUp && !timeNotSet)
        {
            Debug.Log("button can be pressed again");
            this.GetComponent<Button>().stayPressed = true;
            timeNotSet = true;
        }      
	}
}
