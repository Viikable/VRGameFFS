using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class ShaftLightsButton : MonoBehaviour {
    VRTK_PhysicsPusher shaftlightButton;
    GameObject MaintenanceLight;
    Light MaintenanceSpot;
    int switcher;
    bool processing;
	
	void Start () {
        shaftlightButton = GetComponent<VRTK_PhysicsPusher>();
        MaintenanceLight = GameObject.Find("MaintenanceSpotLight");
        MaintenanceSpot = MaintenanceLight.GetComponent<Light>();
        switcher = 0;
        processing = false;

    }
		
	void Update () {

		if (shaftlightButton.AtMaxLimit() && shaftlightButton.stayPressed && switcher % 2 == 0 && !processing)
        {
            processing = true;
            MaintenanceSpot.enabled = true;
            switcher++;
            StartCoroutine("Wait");
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "FirstShaft";
        }
        else if (shaftlightButton.AtMaxLimit() && shaftlightButton.stayPressed && switcher % 2 == 1 && !processing)
        {
            processing = true;
            MaintenanceSpot.enabled = false;
            switcher++;
            StartCoroutine("Wait");
        }
	}
    IEnumerator Wait()
    {
        Debug.Log("wait");
        yield return new WaitForSecondsRealtime(0.5f);
        shaftlightButton.stayPressed = false;
        StartCoroutine("Back");
    }
    IEnumerator Back()
    {
        Debug.Log("back");
        yield return new WaitForSecondsRealtime(0.5f);
        shaftlightButton.stayPressed = true;
        processing = false;
    }
}
